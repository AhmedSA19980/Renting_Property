

namespace SharedDTOLayer.clients.clientsDTO
{
    public class ChangePasswordDTO
    {
        public ChangePasswordDTO(int ClientID, string password)
        {

            this.ClientID = ClientID;
            this.Password = password;
         
         

        }
        public int ClientID { get; set; }
        public string Password { get; set; }
       
    
    }
}
