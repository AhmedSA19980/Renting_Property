

namespace SharedDTOLayer.clients.clientsDTO
{
    public class GetClientDTO
    {
        public GetClientDTO(int ClientID, string username, int personID, byte Role)
        {

            this.ClientID = ClientID;
            this.UserName = username;
           
            this.PersonID = personID;
            this.Role = Role;

        }
        public int ClientID { get; set; }
        public string UserName { get; set; }
  
        public int PersonID { get; set; }
        public byte Role { get; set; }
    }
}

