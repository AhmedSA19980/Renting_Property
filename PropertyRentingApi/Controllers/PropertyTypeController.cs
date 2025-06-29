using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PR_DataAccessLayer;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTypeController : ControllerBase
    {

        [HttpGet("All", Name = "ListPropertyTypes")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

       
        public ActionResult<IEnumerable<PropertyTypeDTO>> ListPropertyTypes() 
        {
            

            List<PropertyTypeDTO> PropertyTypesList = PR_BusinessLayer.clsPropertyType.GetPropertiesType();
            if (PropertyTypesList.Count == 0)
            {
                return NotFound("Not a single  Country is Recroded in data!");
            }
            return Ok(PropertyTypesList); 
        }

        [HttpGet("PropertyTypeID", Name = "GetPropertyTypeByID")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PropertyTypeDTO>> GetPropertyTypeByID(int PropertyTypeID)
        {

            if (PropertyTypeID < 0)
            {

                return BadRequest($"Not accepted ID {PropertyTypeID}");
            }

            PR_BusinessLayer.clsPropertyType PropertyType = PR_BusinessLayer.clsPropertyType.Find((sbyte)PropertyTypeID);
            if (PropertyType == null)
            {
                return NotFound($"Property Type with ID {PropertyType} not found.");
            }

            PropertyTypeDTO DDTO = PropertyType.PDTO;

            return Ok(DDTO);
        }




            [HttpGet("PropertyName", Name = "GetPropertyTypeByName")] 
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<int> GetPropertyTypeByName(string PropertyTypeName)
            {

                if (PropertyTypeName == "")
                {


                    return BadRequest($"Not accepted Name {PropertyTypeName} is empty");
                }

                sbyte PropertyTypeID = PR_BusinessLayer.clsPropertyType.Find(PropertyTypeName).PropertyTypeID;
                if (PropertyTypeID == 0)
                {
                    return NotFound($"Property Type with ID {PropertyTypeID} not found.");
                }

               

                return Ok(PropertyTypeID);
                }
            [HttpGet("PropertyNameByID", Name = "PropertyNameByID")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]

            public ActionResult<IEnumerable<string>> GetCountryNameByID(sbyte PropertyTypeID) 
            {
                

                string PropertyName = PR_BusinessLayer.clsPropertyType.Find(PropertyTypeID).PropertyName;
                if (PropertyName == "")
                {
                    return NotFound("Not a single  Country is Recroded in data!");
                }
                return Ok(PropertyName); // Returns the list of students.

            }



            [HttpPost("AddPropertyType", Name = "AddPropertyTypeName")]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult<PropertyTypeDTO> AddPropertyType(PropertyTypeDTO propertyTypeDTO)
            {
              
                if (propertyTypeDTO == null || propertyTypeDTO.PropertyTypeID == -1 ||
                    string.IsNullOrEmpty(propertyTypeDTO.PropertyTypeName))
                {
                    return BadRequest("Invalid Property data.");
                }

                
                PR_BusinessLayer.clsPropertyType PropertyType = new PR_BusinessLayer.clsPropertyType(new PropertyTypeDTO(propertyTypeDTO.PropertyTypeID, propertyTypeDTO.PropertyTypeName));
                PropertyType.Save();

                propertyTypeDTO.PropertyTypeID =(byte) PropertyType.PropertyTypeID;



                return CreatedAtRoute("AddPropertyTypeName", new { id = propertyTypeDTO.PropertyTypeID }, propertyTypeDTO);


            }

       
            [HttpPost("{updatePTypeByID}", Name = "UpdatePropertyType")]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult<PropertyTypeDTO> UpdatePropertyTypeID(byte updatePTypeByID, PropertyTypeDTO propertyTypeDTO)
            {
                //we validate the data here
                if (propertyTypeDTO == null || propertyTypeDTO.PropertyTypeID == -1 ||
                     string.IsNullOrEmpty(propertyTypeDTO.PropertyTypeName))
                {
                    return BadRequest("Invalid Property data.");
                }

           
                PR_BusinessLayer.clsPropertyType PropertyType = PR_BusinessLayer.clsPropertyType.Find((sbyte)updatePTypeByID);
          

                PropertyType.PropertyTypeID =(sbyte) propertyTypeDTO.PropertyTypeID ;
                PropertyType.PropertyName = propertyTypeDTO.PropertyTypeName;
           
            
                PropertyType.Save();

                return Ok(PropertyType.PDTO);


            }


            [HttpDelete("{PropertyTypeID}", Name = "DeletePropertyType")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult DeletePropertyType(int PropertyTypeID)
            {
                if (PropertyTypeID < 1)
                {
                    return BadRequest($"Not accepted ID {PropertyTypeID}");
                }

          

                if (PR_BusinessLayer.clsPropertyType.Delete((sbyte)PropertyTypeID))

                    return Ok($"PropertyType  with ID {PropertyTypeID} has been deleted.");
                else
                    return NotFound($"PropertyType with ID {PropertyTypeID} not found. no rows deleted!");
            }


    }
}
