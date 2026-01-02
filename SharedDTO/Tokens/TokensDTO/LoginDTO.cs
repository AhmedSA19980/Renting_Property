

namespace SharedDTOLayer.Tokens.TokensDTO
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginDto()
        {
            this.UserName = "";
            this.Password = "";
        }

        public LoginDto(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

}
