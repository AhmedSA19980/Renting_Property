
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using PR_BusinessLayer;
using PR_BusinessLayer.Utilities;
using PR_DataAccessLayer;
using PropertyRentingApi.Utilities;



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
        public ActionResult<ClientDTO> GetClientById(int id)
        {

            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

           

            PR_BusinessLayer.clsClients client = PR_BusinessLayer.clsClients.Find(id);

            if (client == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            
            ClientDTO PDTO = client.CDTO;

          
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
                return NotFound($"Student with ID {id} not found.");
            }

          
            return Ok(clientUserName);

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
                return NotFound($"Student with ID {clientID} not found.");
            }


            FullClientDTO PDTO = client.FCDTO;

            
            return Ok(PDTO);

        }

        [HttpPost("Login", Name = "UserLogin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //  [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public ActionResult<ClientDTO> Login(ClientDTO Clientdto)
        {

            if (string.IsNullOrEmpty(Clientdto.UserName) && string.IsNullOrEmpty(Clientdto.Password))
            {
                return BadRequest($"UserName or Password is not correct !");
            }




            try {
                string hashPass = Utilities.clsGlobal.hashPassword(Clientdto.Password);

         
                PR_BusinessLayer.clsClients Client = clsClients.FindFullInfoUserNameAndPassword(Clientdto.UserName, hashPass);
                if (Client == null)
                {
                    return NotFound("User is not found !");  //Unauthorized($"User is invalid.");
                }
              
                ClientDTO client = Client.CDTO;


                return Ok(client);

            } catch (Exception ex) {


                // Log the exception for debugging purposes (ensure sensitive info isn't logged in production)
                // _logger.LogError(ex, "Error during login attempt for user: {UserName}", Clientdto.UserName);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }

        }




        [HttpPost("Add", Name = "AddClient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FullClientDTO> AddStudent(FullClientDTO ClientDTO)
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

        
            string hashPassword = clsGlobal.hashPassword(ClientDTO.Password);
            PR_BusinessLayer.clsClients client = new PR_BusinessLayer.clsClients(new FullClientDTO(ClientDTO.ClientID,
            ClientDTO.UserName,
            hashPassword,
            ClientDTO.PersonID,
            ClientDTO.PersonID,
                ClientDTO.FirstName, ClientDTO.LastName,
                ClientDTO.DateOfBirth, ClientDTO.Gender, ClientDTO.Address, ClientDTO.NationalityCountryID,
                ClientDTO.Phone, ClientDTO.Email, ClientDTO.PersonalImage));

            client.Save();
            ClientDTO.ClientID = client.ClientID;

            //we return the DTO only not the full client object
            //we dont return Ok here,we return createdAtRoute: this will be status code 201 created.
            return CreatedAtRoute("AddClient", new { id = ClientDTO.ClientID }, ClientDTO);
        }

        [HttpPut("UpdateClientById", Name = "UpdateClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FullClientDTO> UpdateStudent(int UpdateClientById, FullClientDTO ClientDTO)
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
                return BadRequest("Invalid student data.");
            }

           
           
            PR_BusinessLayer.clsClients Client = PR_BusinessLayer.clsClients.Find(UpdateClientById);


            if (Client == null)
            {
                return NotFound($"Student with ID {UpdateClientById} not found.");
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

            //we return the DTO not the full student object.
            return Ok(Client.CDTO);

        }



        [HttpPut("ChangePassword", Name = "ChangePass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClientDTO> ChangePassword(ClientDTO Clientdto)
        {
            if (Clientdto.ClientID == 0)
               
            {
                return BadRequest("Invalid data! ClientID and Password Must be Filled.");
            };

            //var student = StudentDataSimulation.StudentsList.FirstOrDefault(s => s.Id == id);

            PR_BusinessLayer.clsClients client = PR_BusinessLayer.clsClients.Find(Clientdto.ClientID);


            if (client == null)
            {
                return NotFound($"client with ID {Clientdto.ClientID} not found.");
            }


          
          
            client.Password =  Utilities.clsGlobal.hashPassword( Clientdto.Password);
            


            client.Save();

            //we return the DTO not the full student object.
            return Ok(client.CDTO);

        }


        [HttpPut( "BlockClient",Name = "BlockClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> BlockClient(int personID)
        {
            //we validate the data here
            if (personID < 0) 
            {
                return BadRequest("Invalid Id data.");
            }

            //newStudent.Id = StudentDataSimulation.StudentsList.Count > 0 ? StudentDataSimulation.StudentsList.Max(s => s.Id) + 1 : 1;

            PR_BusinessLayer.clsClients BlockPerson = PR_BusinessLayer.clsClients.Find(personID);

            if (BlockPerson == null)
            {
                return NotFound("Client with ID " + personID + " not found.");
            }


            bool isBlocked = PR_BusinessLayer.clsClients.BlockClient(personID);
            BlockPerson.Save();
            return Ok(User);
        }



        [HttpPut("UnBlockClient", Name = "UnBlockClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> UnBlockPerson(int personID)
        {
            //we validate the data here
            if (personID < 0) 
            {
                return BadRequest("Invalid Id data.");
            }

          

            PR_BusinessLayer.clsClients BlockPerson = PR_BusinessLayer.clsClients.Find(personID);

            if (BlockPerson == null)
            {
                return NotFound("Client with ID " + personID + " not found.");
            }

            bool isBlocked = PR_BusinessLayer.clsClients.UnBlockClient(personID);
            BlockPerson.Save();
            return Ok(User);

        }


        [HttpGet("IsUserBlocked", Name = "IsUserBlocked")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsUserBlocked(int personID)
        {
            //we validate the data here
            if (personID < 0)
            {
                return BadRequest("Invalid Id data.");
            }

          
            bool  IsUserBlock = PR_BusinessLayer.clsClients.IsUserBlocked(personID);



            if (IsUserBlock == null)
            {
                return NotFound("Client with ID " + personID + " not found.");
            }


          
            return Ok(IsUserBlock);
        }




        [HttpPut("UploadClientPhoto", Name = "UploadPhoto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UploadClientPhoto(int ClientID , IFormFile PersonalInfo )
        {
            FullClientDTO ClientDTO= new FullClientDTO();
            //we validate the data here


            // check content type if required

          
           

            PR_BusinessLayer.clsClients client = clsClients.Find(ClientID);    

            if (client == null )
            {
                return BadRequest($"Invalid client id {ClientID}!");
            }

            ClientDTO.PersonalImage = await clsUitil.UploadPersonImage(PersonalInfo, _configuration);
            
            if(ClientDTO == null || string.IsNullOrEmpty(ClientDTO.PersonalImage))
            {
                return BadRequest("You must Choose an image!");
            }

            if(client.PersonalImage != "") clsUitil.DeleteFile(PersonalInfo , client.PersonalImage);
            
            client.PersonalImage = ClientDTO.PersonalImage;

            client.Save();

            

            return Ok(client.PersonalImage);


        }



    }
}
