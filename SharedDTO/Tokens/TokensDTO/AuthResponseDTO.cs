

namespace SharedDTOLayer.Tokens.TokensDTO
{

    public class AuthResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; } // Time until access token expires, in seconds
    }

}
