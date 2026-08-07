

using System.Collections.Generic;

namespace Models
{
    public  class SessionManager 
    {
        public int ClientID { get; set; }
        public string UserName { get; set; }
       
        public string email { get; set; }
        public  string AccessToken { get; set; }
        public  string RefreshToken { get; set; }

        public List<string> userRoles { get; set; }

        public SessionManager( int ClientId , string username  , string email , string accesstoken , string refreshtoken , List<string> UserRole) { 
        
            this.ClientID = ClientId;   
            this.UserName = username;
            this.email = email;
            this.AccessToken = accesstoken;
            this.RefreshToken = refreshtoken;   
            this.userRoles = UserRole;

        }

        public SessionManager()
        {

            this.ClientID = -1;
            this.UserName = "";
            this.email = "";
            this.AccessToken = "";
            this.RefreshToken = "";
            this.userRoles= new List<string>();  
        }

    }
}
