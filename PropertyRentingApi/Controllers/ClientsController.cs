using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PR_BusinessLayer;
using SharedDTOLayer.clients.clientsDTO;
using PropertyRentingApi.Utilities;
using System.Security.Claims;
using UtillsLayer;
using SharedDTOLayer.Role;


namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
       

        public ClientsController(IConfiguration configuration) // Constructor injection
        {
            _configuration = configuration;
        }

        [HttpGet("clientInfo", Name = "GetClientInfoId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetClientDTO> GetClientById(int id)
        {

            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

       

            PR_BusinessLayer.clsClients client = PR_BusinessLayer.clsClients.Find(id);

            if (client == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

           
            GetClientDTO PDTO = client.GCDTO;

            return Ok(PDTO);

        }


        [HttpGet("GetClientUserNameById", Name = "GetClientUserNameById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> GetClientUserNameById(int id)
        {

            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }


            string clientUserName = PR_BusinessLayer.clsClients.Find(id).UserName;

            if (clientUserName == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            return Ok(clientUserName);

        }



        [HttpGet("GetClientIdByEmail", Name = "GetClientIdByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<int> GetClientIdByEmail(string email)
        {

            if (string.IsNullOrEmpty(email))
            {
                return BadRequest($"email must not be empty");
            }


            int Useremail = PR_BusinessLayer.clsClients.GetClientIdByPersonEmail(email);

            if (Useremail == -1)
            {
                return NotFound($"Client with  {email} is not found.");
            }

            return Ok(Useremail);

        }



        [HttpGet("GetClientIdByPersonID", Name = "GetClientIdByPersonID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<int> GetClientIdByPersonID(int PersonID)
        {

            if (PersonID <  0 )
            {
                return BadRequest($"Invalid input of Person id -> {PersonID}");
            }


            int clientId = PR_BusinessLayer.clsClients.GetClientIdByPersonID(PersonID);

            if (clientId == -1)
            {
                return NotFound($"Client with person id = {PersonID} is not found.");
            }

            return Ok(clientId);

        }

        [HttpGet("getPersonInfo", Name = "getPersonInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FullClientDTO> getPersonInfo(int clientID)
        {

            if (clientID < 1)
            {
                return BadRequest($"Not accepted ID {clientID}");
            }

            PR_BusinessLayer.clsClients client = PR_BusinessLayer.clsClients.Find(clientID);

            if (client == null)
            {
                return NotFound($"Client with ID {clientID} not found.");
            }

           
            FullClientDTO PDTO = client.FCDTO;

            return Ok(PDTO);

        }

    

        [HttpPost("Add", Name = "AddClient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FullClientDTO> AddClient(FullClientDTO ClientDTO)
        {
            //we validate the data here
            if (ClientDTO == null || string.IsNullOrEmpty(ClientDTO.UserName) || string.IsNullOrEmpty(ClientDTO.Password) ||
                ClientDTO.PersonID == -1 || string.IsNullOrEmpty(ClientDTO.FirstName) ||
                string.IsNullOrEmpty(ClientDTO.LastName) ||
                ClientDTO.DateOfBirth == default(DateTime) ||
                ClientDTO.Address == "" ||
                ClientDTO.NationalityCountryID == -1
                || string.IsNullOrEmpty(ClientDTO.Phone)
                || string.IsNullOrEmpty(ClientDTO.Email)


                )
            {
                return BadRequest("Invalid Client data.");
            }

           
            string hashPassword =clsPassProcedures.hashPassword(ClientDTO.Password);
            PR_BusinessLayer.clsClients client = new PR_BusinessLayer.clsClients(new FullClientDTO(ClientDTO.ClientID,
            ClientDTO.UserName,
            hashPassword,
            ClientDTO.PersonID,
            ClientDTO.Role,// Client Role
            ClientDTO.PersonID,
                ClientDTO.FirstName, ClientDTO.LastName,
                ClientDTO.DateOfBirth, ClientDTO.Gender, ClientDTO.Address, ClientDTO.NationalityCountryID,
                ClientDTO.Phone, ClientDTO.Email, ClientDTO.PersonalImage));

            client.Save();
            ClientDTO.ClientID = client.ClientID;

            
            return CreatedAtRoute("AddClient", new { id = ClientDTO.ClientID }, ClientDTO);
        }



        [Authorize]
        [HttpPut("UpdateClientById", Name = "UpdateClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FullClientDTO> UpdateClient(int UpdateClientById, UpdateClientDTO ClientDTO)
        {
            if (UpdateClientById < 1 || ClientDTO == null || string.IsNullOrEmpty(ClientDTO.UserName)  ||
                ClientDTO.PersonID == -1 || string.IsNullOrEmpty(ClientDTO.FirstName) ||
                string.IsNullOrEmpty(ClientDTO.LastName) ||
                ClientDTO.DateOfBirth == default(DateTime) ||
                ClientDTO.Address == "" ||
                ClientDTO.NationalityCountryID == -1
                || string.IsNullOrEmpty(ClientDTO.Phone)
                || string.IsNullOrEmpty(ClientDTO.Email))
            {
                return BadRequest("Invalid Client data.");
            }

            

            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            if (Convert.ToInt32(userIdStr) != UpdateClientById) return Unauthorized("you're not authorized to update this client, make sure you input your client id number ");

            PR_BusinessLayer.clsClients Client = PR_BusinessLayer.clsClients.Find(UpdateClientById);


            if (Client == null)
            {
                return NotFound($"Client with ID {UpdateClientById} not found.");
            }


            Client.ClientID = ClientDTO.ClientID;
            Client.UserName = ClientDTO.UserName;
         
            Client.PersonID = ClientDTO.PersonID;
            Client.DateOfBirth = ClientDTO.DateOfBirth;
            Client.FirstName = ClientDTO.FirstName;
            Client.LastName = ClientDTO.LastName;
            Client.Gender = ClientDTO.Gender;
            Client.Address = ClientDTO.Address;
            Client.Phone = ClientDTO.Phone;
            Client.Email = ClientDTO.Email;
            Client.PersonalImage = ClientDTO.PersonalImage;
            Client.NationalityCountryID = ClientDTO.NationalityCountryID;

           
            Client.Save();

            
            return Ok(Client.UCDTO);

        }


        [Authorize]
        [HttpPut("ChangePassword", Name = "ChangePass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<ClientDTO> ChangePassword(ChangePasswordDTO Clientdto)
        {

            if (Clientdto.ClientID == 0)
               
            {
                return BadRequest("Invalid data! ClientID and Password Must be Filled.");
            };


            string userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            if (Convert.ToInt32(userId) != Clientdto.ClientID) return Unauthorized("you're not authorized to update this client, make sure you input your client id number ");


          

            PR_BusinessLayer.clsClients client = PR_BusinessLayer.clsClients.Find(Clientdto.ClientID);
           

            if (client == null)
            {
                return NotFound($"client with ID {Clientdto.ClientID} not found.");
            }



      
            client.Password =clsPassProcedures.hashPassword( Clientdto.Password);
            


            client.Save();

            return Ok(client.CDTO);

        }

        [Authorize(Policy = "Admin")]
        [HttpPut( "BlockClient",Name = "BlockClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<bool> BlockClient(int ClientID)
        {
            if (ClientID < 0) 
            {
                return BadRequest("Invalid Id data.");
            }

          
            PR_BusinessLayer.clsClients BlockPerson = PR_BusinessLayer.clsClients.Find(ClientID);

            if (BlockPerson == null)
            {
                return NotFound("Client with ID " + ClientID + " not found.");
            }


            bool isBlocked = PR_BusinessLayer.clsClients.BlockClient(ClientID);
            BlockPerson.Save();
            return Ok(isBlocked);
        }


        [Authorize(Policy = "Admin")]
        [HttpPut("UnBlockClient", Name = "UnBlockClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<bool> UnBlockPerson(int ClientID)
        {
     
            if (ClientID < 0) 
            {
                return BadRequest("Invalid Id data.");
            }


            PR_BusinessLayer.clsClients BlockPerson = PR_BusinessLayer.clsClients.Find(ClientID);

            if (BlockPerson == null)
            {
                return NotFound("Client with ID " + ClientID + " not found.");
            }

            bool isBlocked = PR_BusinessLayer.clsClients.UnBlockClient(ClientID);
            BlockPerson.Save();
            return Ok(isBlocked);

        }



      


        [HttpGet("IsUserBlocked", Name = "IsUserBlocked")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsUserBlocked(int ClientID)
        {
            
            if (ClientID < 0)
            {
                return BadRequest("Invalid Id data.");
            }

         
            bool  IsUserBlock = PR_BusinessLayer.clsClients.IsUserBlocked(ClientID);



            if (IsUserBlock == null)
            {
                return NotFound("Client with ID " + ClientID + " not found.");
            }

            return Ok(IsUserBlock);
        }




        [HttpPut("UploadClientPhoto", Name = "UploadPhoto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UploadClientPhoto(int ClientID , IFormFile PersonalInfo )
        {
            FullClientDTO ClientDTO= new FullClientDTO();
            
            PR_BusinessLayer.clsClients client = clsClients.Find(ClientID);    

            if (client == null )
            {
                return BadRequest($"Invalid client id {ClientID}!");
            }

            ClientDTO.PersonalImage = await clsMedia.UploadPersonImage(PersonalInfo, _configuration);
            
            if(ClientDTO == null || string.IsNullOrEmpty(ClientDTO.PersonalImage))
            {
                return BadRequest("You must Choose an image!");
            }

            if(client.PersonalImage != "") clsMedia.DeleteFile(PersonalInfo , client.PersonalImage);
            
            client.PersonalImage = ClientDTO.PersonalImage;

            client.Save();

            
            return Ok(client.PersonalImage);


        }


    }
}
