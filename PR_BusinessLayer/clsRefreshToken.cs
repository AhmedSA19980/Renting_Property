
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PR_DataAccessLayer;
using SharedDTOLayer.Tokens.TokensDTO;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UtillsLayer;



namespace PR_BusinessLayer
{
    public class clsRefreshToken
    {

        
        private readonly IConfiguration _configuration;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string? RevokedByIp { get; set; }
        public string? ReplacedByToken { get; set; }
        public string? ReasonRevoked { get; set; }
        public int ClientId { get; set; }

        public RefreshTokenDTO RTDTO
        {
            get
            {
                return (new RefreshTokenDTO(
           this.Id,
           this.Token,
           
           this.Expires,
           this.Created,
            this.CreatedByIp,
           this.Revoked,
           this.RevokedByIp,
           this.ReplacedByToken,
           this.ReasonRevoked,
         
           this.ClientId
           ));
            }

        }

       // public clsRefreshToken() { }
        public clsRefreshToken(IConfiguration configuration)
        {
            _configuration = configuration;

        }
     

       


        public clsRefreshToken(IConfiguration configuration, RefreshTokenDTO RTDTO, enMode cMode = enMode.AddNew)
        {

            this.Id = RTDTO.Id;
            this.Token = RTDTO.Token;
            this.Expires = RTDTO.Expires;
            this.Created = RTDTO.Created;
            this.CreatedByIp = RTDTO.CreatedByIp;
            this.Revoked = RTDTO.Revoked;
            this.RevokedByIp = RTDTO.RevokedByIp;
            this.ReplacedByToken = RTDTO.ReplacedByToken;
            this.ReasonRevoked = RTDTO.ReasonRevoked;
            this.ClientId = RTDTO.ClientId;
            _configuration = configuration;


            _Mode = cMode;
        }


       
        public  async Task<AuthResponseDto> AuthenticateAysnc(LoginDto clientdto, string IpAddress)
        {
            try
            {
                
                string hashPass = clsPassProcedures.hashPassword(clientdto.Password);

                //  bool user = PR_BusinessLayer.clsClients.FindUserInfoNameAndPassword(UserName, hashPass);
                PR_BusinessLayer.clsClients Client =   clsClients.FindFullInfoUserNameAndPassword(clientdto.UserName, hashPass);
                if (Client == null)
                {
                    return null;
                }

                string clientId =Convert.ToString( Client.ClientID);
                string username = clientdto.UserName;


                var claims =await GetUserClaims(Convert.ToString( clientId) , username ,(byte) Client.Role);
                var accessToken = GenerateAccessToken(claims);
                var refreshToken = GenerateRefreshToken();

                refreshToken.ClientId =Convert.ToInt32( clientId); // Assign the actual user ID
                refreshToken.CreatedByIp = IpAddress;

                await clsResfreshTokenData.AddNewRefreshToken(refreshToken);


                return new AuthResponseDto
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken.Token,
                    ExpiresIn = _configuration.GetValue<int>("Jwt:AccessTokenExpirationMinutes") * 60
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            };

        }


        private RefreshTokenDTO GenerateRefreshToken()
        {
            var refreshTokenExpirationDays =_configuration.GetValue<int>("Jwt:RefreshTokenExpirationDays");

            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return new RefreshTokenDTO
            {
             
                Token = Convert.ToBase64String(randomNumber),
                Expires = DateTime.UtcNow.AddDays(refreshTokenExpirationDays),
                Created = DateTime.UtcNow,
               
  
            };
        }


        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var jwtKey = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var accessExpirationMinutes = _configuration.GetValue<int>("Jwt:AccessTokenExpirationMinutes");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(accessExpirationMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        private async Task<List<Claim>> GetUserClaims(string clientId, string userName , byte Role)
        {
            var roles = new List<string> { "User", Convert.ToString(Role) };


            var claims = new List<Claim>
                {

                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString( clientId)),
                    new Claim(ClaimTypes.Name, userName)
                };
            

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role)); // Add roles as claims
            }

            
            return claims;
        }



        public async Task<AuthResponseDto?> RefreshAccessTokenAsync(string oldRefreshTokenString, string ipAddress)
        {

            var existingRefreshToken = await clsResfreshTokenData.GetRefreshTokenByTokenAsync(oldRefreshTokenString);

            if (existingRefreshToken == null || existingRefreshToken.IsRevoked || existingRefreshToken.IsExpired)
            {
                if(existingRefreshToken != null)
                {
                    await clsResfreshTokenData.RevokeAllRefreshTokensForUser(existingRefreshToken, Convert.ToString( existingRefreshToken.ClientId));
                    existingRefreshToken.ReasonRevoked = "Attempted use of invalid/revoked refresh token.";
                }
                return null;
            }


            existingRefreshToken.Revoked = DateTime.UtcNow;
            existingRefreshToken.RevokedByIp = ipAddress;
            existingRefreshToken.ReasonRevoked = "used for refresh";

            clsClients client = clsClients.Find(existingRefreshToken.ClientId);

 

            var claims = await GetUserClaims(Convert.ToString( existingRefreshToken.ClientId),client.UserName,(byte) client.Role);
            var newAccessToken = GenerateAccessToken(claims);
            var newRefreshToken = GenerateRefreshToken();

            newRefreshToken.ClientId = existingRefreshToken.ClientId;
            newRefreshToken.CreatedByIp = ipAddress;

            existingRefreshToken.ReplacedByToken = newRefreshToken.Token; // Link old to new


            await clsResfreshTokenData.UpdateRefreshTokenAsync(existingRefreshToken);
            await clsResfreshTokenData.AddNewRefreshToken(newRefreshToken);


            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token,
                ExpiresIn = _configuration.GetValue<int>("Jwt:AccessTokenExpirationMinutes") * 60
            };


        }

        public async Task<bool> RevokeRefreshTokenAsync(string refreshTokenString, string clientIdFromAccessToken , string IpAddress)
        {
            var refresToken = await clsResfreshTokenData.GetRefreshTokenByTokenAsync(refreshTokenString);
            if(refresToken == null || refresToken.IsRevoked || refresToken.IsExpired)
            {
                return false;
            }
            if(Convert.ToString( refresToken.ClientId) != clientIdFromAccessToken)
            {
                return false;   
            }


            refresToken.Revoked = DateTime.UtcNow;
            refresToken.RevokedByIp = IpAddress;
            refresToken.ReasonRevoked = "Manual Revocation by User";



            await clsResfreshTokenData.UpdateRefreshTokenAsync(refresToken);
            return true;




        }


        private async Task< bool> _AddNewRefreshToken()
        {
            // Call DataAccess Layer
            this.Id =await clsResfreshTokenData.AddNewRefreshToken(RTDTO);

            return (this.Id != -1);
        }

        private async Task< bool> _UpdateRefreshToken()
        {
            // Call DataAccess Layer
            return  clsResfreshTokenData.UpdateRefreshTokenAsync(RTDTO) != null;
        }


        public static async Task< clsRefreshToken> Find(string Token)
        {
            RefreshTokenDTO RTDTO = await clsResfreshTokenData.GetRefreshTokenByTokenAsync(Token);
            IConfiguration conf = null;
            if (RTDTO != null)
            {
                return new clsRefreshToken(conf ,RTDTO, enMode.Update);
            }
            else
                return null;
        }


        public async Task<bool>  RevokeAllRefreshTokensForUser(string clientID)
        {   
               return await clsResfreshTokenData.RevokeAllRefreshTokensForUser(RTDTO , clientID);
        }

        public async Task< bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewRefreshToken())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return await _UpdateRefreshToken();

                default:
                    return false;
            }
        }



    }
}
