using Microsoft.AspNetCore.Mvc;
using PR_DataAccessLayer;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using SharedDTOLayer.Images;
using SharedDTOLayer.Properties_.PropertiesDTO;
using SharedDTOLayer.ProperiesOwner.PropertiesOwnerDTO;


namespace PropertyRentingApi.Controllers
{
    [Route("api/Property")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
       
        [HttpGet("All", Name = "GetAllProperties")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

  
        public ActionResult<IEnumerable<PropertyDTO>> GetAllProperties()
        {
           

            List<PropertyDTO> PropertyList = PR_BusinessLayer.clsProperty.GetAllProperties();
            if (PropertyList.Count == 0)
            {
                return NotFound("No Property is Found!");
            }
            return Ok(PropertyList); 

        }

        [HttpGet("AllActive", Name = "GetAllActiveProperties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public ActionResult<IEnumerable<PropertyDTO>> GetAllActiveProperties()
        {


            List<PropertyDTO> PropertyList = PR_BusinessLayer.clsProperty.GetAllActiveProperties();
            if (PropertyList.Count == 0)
            {
                return NotFound("No Property is Found!");
            }
            return Ok(PropertyList);

        }


        [HttpGet("Random", Name = "GetRandomProperties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

       
        public ActionResult<IEnumerable<PropertyDTO>> GetRandomProperties() 
        {


            int PropertyList = PR_BusinessLayer.clsProperty.GetRandomPropertyID();
            if (PropertyList == -1)
            {
                return NotFound("No Property is Found!");
            }
            return Ok(PropertyList); 

        }

        [HttpGet("GetPropertyById", Name = "GetPropertyById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<PropertyDTO>> GetPropertyById(int PropertyID)
        {

            if (PropertyID < 0) {

                return BadRequest($"Not accepted ID {PropertyID}");
            }

            PR_BusinessLayer.clsProperty Property = PR_BusinessLayer.clsProperty.Find(PropertyID);
            if (Property == null)
            {
                return NotFound($"Property with ID {PropertyID} not found.");
            }

            PropertyDTO PDTO = Property.PDTO;

            return Ok(PDTO);
        }




        [HttpGet("GetPropertyByIDWithContainer", Name = "GetPropertyByIDWithContainer")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<PropertyDTOWithContainerDTO>> GetPropertyByIDWithContainer(int PropertyID)
        {

            if (PropertyID < 0)
            {

                return BadRequest($"Not accepted ID {PropertyID}");
            }

            PR_BusinessLayer.clsProperty Property = PR_BusinessLayer.clsProperty.Find(PropertyID);
            PR_BusinessLayer.clsImages Container = PR_BusinessLayer.clsImages.Find(Property.ContainerID);
            if (Property == null)
            {
                return NotFound($"Property with ID {PropertyID} not found.");
            }
            if(Container == null)
            {
                return NotFound($"Property with container ID {Property.ContainerID} is not found.");
            }
            PropertyDTO PDTO = Property.PDTO;
            ImagesDTO CDTO  = Container.IDTO;

            var PropertydtoWithContainerdto = new PropertyDTOWithContainerDTO
            {
                Property = PDTO,
                Container =  CDTO
            };
            return Ok(PropertydtoWithContainerdto);
        }



        [HttpGet("GetPropertyID", Name = "GetPropertyID")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<int> GetPropertyId(int PropertyID)
        {

            if (PropertyID < 0)
            {

                return BadRequest($"Not accepted ID {PropertyID}");
            }

            int GetPropertyID = PR_BusinessLayer.clsProperty.Find(PropertyID).PropertyID;
            if (GetPropertyID == 0)
            {
                return NotFound($"Property with ID {PropertyID} not found.");
            }

            return Ok(GetPropertyID);
        }


        [HttpGet("GetPropertyNameByID", Name = "GetPropertyNameByID")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<string> GetPropertyNameByID(int PropertyID)
        {

            if (PropertyID < 0)
            {

                return BadRequest($"Not accepted ID {PropertyID}");
            }

            string GetPropertyName = PR_BusinessLayer.clsProperty.Find(PropertyID).Name;
            if (GetPropertyName == null)
            {
                return NotFound($"Property with ID {PropertyID} not found.");
            }

            return Ok(GetPropertyName);
        }

        [HttpGet("GetPropertyPriceByID", Name = "GetPropertyPriceByID")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<decimal> GetPropertyPriceByID(int PropertyID)
        {

            if (PropertyID < 0)
            {

                return BadRequest($"Not accepted ID {PropertyID}");
            }

            decimal GetPropertyPrice = PR_BusinessLayer.clsProperty.Find(PropertyID).Price;
            if (GetPropertyPrice == 0)
            {
                return NotFound($"Property with ID {PropertyID} not found.");
            }

            return Ok(GetPropertyPrice); // price refers to US dollar
        }

        [Authorize]
        [HttpPost( "Add", Name = "AddProperty")] // before adding property , add container(images) first  than comeback to property !
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PropertyDTO> AddProperty(PropertyDTO newPropertyDTO)
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            
            if (newPropertyDTO == null || newPropertyDTO.CountryID == -1 || newPropertyDTO.NumberOfBedrooms == -1 ||
                newPropertyDTO.NumberOfBathrooms == -1 ||
                string.IsNullOrEmpty(newPropertyDTO.City) || string.IsNullOrEmpty(newPropertyDTO.Address) ||
                newPropertyDTO.ContainerID == -1 || string.IsNullOrEmpty(newPropertyDTO.Name) || newPropertyDTO.Price ==0)
            {
                return BadRequest("Invalid Property data.");
            }

          
            PR_BusinessLayer.clsProperty property = new PR_BusinessLayer.clsProperty(new PropertyAndClientDTO(
                Convert.ToInt32(userIdStr),
                newPropertyDTO.PropertyID,
                newPropertyDTO.CountryID, newPropertyDTO.City, newPropertyDTO.Address,
                newPropertyDTO.PlaceDescription , newPropertyDTO.ContainerID,
                newPropertyDTO.NumberOfBedrooms
                , newPropertyDTO.NumberOfBathrooms, 
                newPropertyDTO.PropertyTypeID,
                newPropertyDTO.Price,
                newPropertyDTO.Name));
           
            
            PropertyAndClientDTO PropertyAndClient;

           
            property.Save();


            newPropertyDTO.PropertyID = property.PropertyID;

           
            return CreatedAtRoute("GetPropertyById", new { id = newPropertyDTO.PropertyID }, property);

        }


        [Authorize]
        [HttpPut("UpdateProperty", Name = "UpdateProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PropertyDTO> UpdatedProperty( PropertyDTO updatedPropertyDTO)
        {
            if (updatedPropertyDTO == null || updatedPropertyDTO.CountryID == -1 ||
                updatedPropertyDTO.NumberOfBedrooms == -1 ||
                updatedPropertyDTO.NumberOfBathrooms == -1 ||
                string.IsNullOrEmpty(updatedPropertyDTO.City) ||
                string.IsNullOrEmpty(updatedPropertyDTO.Address) ||
                updatedPropertyDTO.ContainerID == -1 ||
                string.IsNullOrEmpty(updatedPropertyDTO.Name)
                )
            {
                return BadRequest("Invalid Property data.");
            }
            int id = -1;
            string userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            int PropertyOwner = PR_BusinessLayer.clsPropertyOwner.GetPropertyClientIdByPropertyID(updatedPropertyDTO.PropertyID);
           

            if (Convert.ToInt32(userIdStr) != PropertyOwner) return Unauthorized("you're not authorized to update this Property, make sure you input your client id number ");



            PR_BusinessLayer.clsProperty Property = PR_BusinessLayer.clsProperty.Find(updatedPropertyDTO.PropertyID);


            if (Property == null)
            {
                return NotFound($"Property with ID {updatedPropertyDTO.PropertyID} not found.");
            }


            Property.Name = updatedPropertyDTO.Name;
            Property.CountryID = updatedPropertyDTO.CountryID;
            Property.NumberOfBedrooms = updatedPropertyDTO.NumberOfBedrooms;
            Property.NumberOfBathrooms = updatedPropertyDTO.NumberOfBathrooms;
            Property.City = updatedPropertyDTO.City;
            Property.Address = updatedPropertyDTO.Address;
            Property.Price = updatedPropertyDTO.Price;
            Property.PlaceDescription = updatedPropertyDTO.PlaceDescription;
            Property.ContainerID = updatedPropertyDTO.ContainerID;
            Property.PropertyTypeID = (sbyte)updatedPropertyDTO.PropertyTypeID;



            Property.Save();

           
            return Ok(Property.PDTO);

        }


        [Authorize]
        [HttpDelete("{id}", Name = "DeleteProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteProperty(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

          
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            int PropertyOwner = PR_BusinessLayer.clsPropertyOwner.GetPropertyClientIdByPropertyID(id);

            if (Convert.ToInt32(userIdStr) != PropertyOwner) return Unauthorized("you're not authorized to update this client, make sure you input your client id number ");



            if (PR_BusinessLayer.clsProperty.DeleteProperty(id) != -1)

                return Ok($"Property with ID {id} has been deleted.");
            else
                return NotFound($"Property  with ID {id} not found. no rows deleted!");
        }



        [HttpGet("GetPropertiesAndStatusByClientID", Name = "GetPropertiesAndStatusByClientID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<ICollection<PropertyStatusDTO>> GetPropertiesAndStatusByClientID(int ClientID)
        {

            if (ClientID < 0)
            {

                return BadRequest($"Not accepted ID {ClientID}");
            }

            ICollection<PropertyStatusDTO> Properties = PR_BusinessLayer.clsProperty.GetAllPropertiesByClientID(ClientID);
            if (Properties == null)
            {
                return NotFound($"Property Owner with client ID {ClientID} is not found.");
            }

            return Ok(Properties);
        }


    }
}
