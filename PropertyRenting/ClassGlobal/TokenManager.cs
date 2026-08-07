using Meziantou.Framework.Win32;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace PropertyRenting.ClassGlobal
{
    public class TokenManager
    {

        public static void SaveToken(string accessToken, string refreshToken)
        {
            const string ResourceName = "PropertyRenting.AuthLogin";
            // Combine the tokens into a single string to save them
            string tokenData = $"{accessToken}|{refreshToken}";
            try {
                CredentialManager.WriteCredential(
                    applicationName: ResourceName,
                    userName: clsGlobal.CurrentUser.UserName,
                    secret: tokenData,
                    comment: "API tokens for MyCool Property Renting App",
                    persistence: CredentialPersistence.LocalMachine

                    );
            
            } catch (Exception ex) {
                Console.WriteLine($"Error saving credentials: {ex.Message}");

            }
        }

        public static bool IsTokenValid(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            return token.ValidTo < DateTime.UtcNow;

        }

        public static (string accessToken, string refreshToken) LoadToken()
        {
            const string ResourceName = "PropertyRenting.AuthLogin";

            try {

                var credential = CredentialManager.ReadCredential(ResourceName);

                if (credential != null && !string.IsNullOrEmpty(credential.Password)) {

                    var tokens = credential.Password.Split('|');
                    if (tokens.Length == 2)
                    {
                        return (tokens[0], tokens[1]);
                    }
                }

            } catch (Exception ex) {

                Console.WriteLine($"Error reading credentials: {ex.Message}");
            }
            return (null, null);    

        }

        public static void DeleteTokens()
        {
            const string ResourceName = "PropertyRenting.AuthLogin";

            try
            {
                CredentialManager.DeleteCredential(ResourceName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting credentials: {ex.Message}");
            }
        }



    }
}
