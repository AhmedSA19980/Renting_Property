using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PR_BusinessLayer;
using SharedDTOLayer.Tokens.TokensDTO;
using System.Security.Claims;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;


        [HttpPost("Login", Name = "UserLogin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       

        public async Task<IActionResult> Login([FromBody] LoginDto Clientdto)
        {

            if (string.IsNullOrEmpty(Clientdto.UserName) && string.IsNullOrEmpty(Clientdto.Password))
            {
                return BadRequest($"UserName or Password is not correct !");
            }



            try
            {
                

                clsRefreshToken _Auth = new clsRefreshToken(_configuration);
                var IpAdd = GetIpAddress();
                var auth = await _Auth.AuthenticateAysnc(Clientdto, IpAdd);

                if (auth == null)
                {
                    return Unauthorized("Invalid Credentials");
                }

                return Ok(auth);

            }
            catch (Exception ex)
            {
               
                // Log the exception for debugging purposes (ensure sensitive info isn't logged in production)
                // _logger.LogError(ex, "Error during login attempt for user: {UserName}", Clientdto.UserName);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }

        }



        public AuthController(IConfiguration configuration) // Constructor injection
        {
            _configuration = configuration;
        }


        [HttpPost("refresh-token", Name = "refresh-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto token)
        {
            clsRefreshToken Token = new clsRefreshToken(_configuration);
            var IpAdd = GetIpAddress();
            var refreshToken = await Token.RefreshAccessTokenAsync(token.RefreshToken, IpAdd);
            if (refreshToken == null)
            {
                return BadRequest("Invalid or expired refresh token.");
            }

            return Ok(refreshToken);

        }

     
        [Authorize] // Requires a valid access token
        [HttpPost("revoke-token" , Name ="Revoke-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] 
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequestDto Token)
        {
            var clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if(clientId == null)// If not authorized to revoke
            {
                return Unauthorized("User ID not found in token."); 
            }

            clsRefreshToken _Auth = new clsRefreshToken(_configuration);
            var IpAdd = GetIpAddress();
            var auth = await _Auth.RevokeRefreshTokenAsync(Token.RefreshToken, clientId ,IpAdd);
            if (!auth) {

                var refresToken = await clsRefreshToken.Find(Token.RefreshToken);
                if (refresToken != null && Convert.ToString(refresToken.RTDTO.ClientId) != clientId) {
                    return Forbid("You are not authorized to revoke this token.");
                }

                return BadRequest("Invalid or already revoked refresh token, or not found.");
            }

            return Ok("Refresh token revoked successfully.");
        }


        private string GetIpAddress()
        {
            // Get IP address of the client
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? "N/A";
        }
    }
}

