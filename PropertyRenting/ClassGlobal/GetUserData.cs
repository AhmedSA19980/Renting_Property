using ApiClient;
using Microsoft.VisualBasic.ApplicationServices;
using Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading.Tasks;

namespace PropertyRenting.ClassGlobal
{
    public class GetUserData
    {
      
        public  static async Task<bool> InitializeSession()
        {
            (string accessToken, string refreshToken) = TokenManager.LoadToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                // no store token , user must log in
                return false;
            }

            clsAPIFunctions<object>.setAuthorizationToken(accessToken);

      
            try {
                if (!TokenManager.IsTokenValid(accessToken))
                {
                    if (clsGlobal.CurrentUser == null)
                    {
                        clsGlobal.CurrentUser = new Models.SessionManager();
                    }
                   
                    clsGlobal.CurrentUser.AccessToken  =  accessToken;
                    clsGlobal.CurrentUser.RefreshToken = refreshToken;
                   
                    var userToken =await clsAPIFunctions<Models.userData>.getUserData();
                    if (int.TryParse(userToken.userId, out int clientId))
                    {
                        clsGlobal.CurrentUser.ClientID = clientId;
                    }

                    var userSession = await CurrentUserSession(Convert.ToInt32(userToken.userId));//await ApiClient.clsAPIFunctions<Models.Client>.GetAsync("Clients/getPersonInfo?clientID=", Convert.ToInt32(userToken.Result.userId));
                   
                    clsGlobal.CurrentUser.UserName = userSession.UserName; // userSession.Result.UserName

                  
                }
                var userInfo =await ApiClient.clsAPIFunctions<Models.userData>.GetAsync2("UserData/data");//await ApiClient.clsAPIFunctions<Models.userData>.GetAsync2("UserData/data").Result


                if (userInfo.IsSuccess != false ) {

                    
                    clsGlobal.CurrentUser.userRoles = userInfo.Value.userRoles; 
                    return true;
                

                }
                else if( userInfo.Error.Contains("Unauthorized")){
                    // The access token is expired; proceed to refresh.
                    // Step 4: Token Refresh
                    if (await TryRefreshToken(refreshToken))
                    {
                        // Refresh was successful.
                        return true;
                    }
                }

            }
            catch
            {
                // An error occurred; force the user to log in again.
                return false;
            }
            return false;
        }
        
        
        private static async  Task<Models.Client> CurrentUserSession(int clientId)
        {
            var userSession = await ApiClient.clsAPIFunctions<Models.Client>.GetAsync("Clients/getPersonInfo?clientID=", clientId);
            return userSession;
        }

       
        public static void RefreshToken(string refreshToken)
        {
            TryRefreshToken(refreshToken);
        }
        private  static async Task<bool> TryRefreshToken(string refreshToken)
        {
            try { 
                    
                var refreshData = new {RefreshToken = refreshToken};

                var newToken = await ApiClient.clsAPIFunctions<Models.Token>.PostAsync("Auth/refresh-token", refreshData);//await ApiClient.clsAPIFunctions<Models.Token>.PostAsync("Auth/refresh-token", refreshData).Result;

                if (newToken != null && !string.IsNullOrEmpty(newToken.AccessToken)) {

                    ApiClient.clsAPIFunctions<object>.setAuthorizationToken(newToken.AccessToken);
                    
                    if (clsGlobal.CurrentUser == null)
                    {
                        clsGlobal.CurrentUser = new Models.SessionManager();
                    }
                    
                    clsGlobal.CurrentUser.AccessToken = newToken.AccessToken;
                    clsGlobal.CurrentUser.RefreshToken = newToken.RefreshToken;
                    
                    var userToken =await  clsAPIFunctions<Models.userData>.getUserData();
                    if (int.TryParse(userToken.userId, out int clientId))
                    {
                        clsGlobal.CurrentUser.ClientID = clientId;
                    }
                    
                    
                    var userSession =await  ApiClient.clsAPIFunctions<Models.Client>.GetAsync("Clients/getPersonInfo?clientID=", Convert.ToInt32(userToken.userId));
                    
                    clsGlobal.CurrentUser.UserName = userSession.UserName;
                    clsGlobal.CurrentUser.userRoles  =userToken.userRoles;
                    TokenManager.SaveToken(newToken.AccessToken , newToken.RefreshToken);

                   
                   
                    return true;
                }
            
            } catch (HttpRequestException ex) {

                // Refresh token is invalid or expired.
                // Clear the old tokens to force currentUser new login.
                TokenManager.DeleteTokens();
            }
        
            return false;
        }

        }
}
