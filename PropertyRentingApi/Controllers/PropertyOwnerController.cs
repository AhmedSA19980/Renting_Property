using Microsoft.AspNetCore.Mvc;
using PR_DataAccessLayer;
using SharedDTOLayer.ProperiesOwner.PropertiesOwnerDTO;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyOwnerController : ControllerBase
    {


        [HttpGet("getPropertyOwnerbyID", Name = "getPropertyOwnerbyID")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<PropertyOwnerDTO>> GetDicountById(int PropertyOwnerID)
        {

            if (PropertyOwnerID < 0)
            {

                return BadRequest($"Not accepted ID {PropertyOwnerID}");
            }

            PR_BusinessLayer.clsPropertyOwner PropertyOwner = PR_BusinessLayer.clsPropertyOwner.Find(PropertyOwnerID);
            if (PropertyOwner == null)
            {
                return NotFound($"PropertyOwner with ID {PropertyOwner} not found.");
            }

            PropertyOwnerDTO PODTO = PropertyOwner.PODTO;

            return Ok(PODTO);
        }


        [HttpGet("getPropertyClientIDbyPropertyID", Name = "getPropertyClientIDbyPropertyID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<int> getPropertyClientIDbyPropertyID(int PropertyID)
        {

            if (PropertyID < 0)
            {

                return BadRequest($"Not accepted ID {PropertyID}");
            }

            int PropertyClientId = PR_BusinessLayer.clsPropertyOwner.GetPropertyClientIdByPropertyID(PropertyID);
            if (PropertyClientId == -1)
            {
                return NotFound($"PropertyOwner with ID {PropertyClientId} not found.");
            }

           

            return Ok(PropertyClientId);
        }



        [HttpGet("GetAllPropertiesByClientID", Name = "GetAllPropertiesByClientID")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<List<PropertyOwnerDTO>> GetAllPropertiesByClientID(int ClientID)
        {

            if (ClientID < 0)
            {

                return BadRequest($"Not accepted ID {ClientID}");
            }

            List<PropertyOwnerDTO> Properties = PR_BusinessLayer.clsPropertyOwner.GetAllByPropertyID(ClientID);
            if (Properties == null)
            {
                return NotFound($"Property Owner with client ID {ClientID} not found.");
            }

            return Ok(Properties);
        }


    }
}
