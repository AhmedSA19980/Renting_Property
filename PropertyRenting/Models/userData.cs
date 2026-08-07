

using System.Collections.Generic;

namespace Models
{
    public class userData
    {
        public string message { get; set; }
        public string userId { get; set; }
        public List<string> userRoles { get; set; }
        public bool isAuthenticated { get; set; }
    }
}
