

namespace SharedDTOLayer.clients.clientsDTO
{
    public  class ClientDTO
    {
            public ClientDTO(int ClientID, string username, string password, int personID, byte Role)
            {

                this.ClientID = ClientID;
                this.UserName = username;
                this.Password = password;
                this.PersonID = personID;
                this.Role = Role;

            }
            public int ClientID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public int PersonID { get; set; }
            public byte Role { get; set; }
        }


    
}
