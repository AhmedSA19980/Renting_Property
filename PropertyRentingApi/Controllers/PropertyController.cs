using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PR_BusinessLayer;
using PR_DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Xml.Linq;
using FileSignatures;

using FileSignatures.Formats;
using PropertyRentingApi.Utilities;

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

            return Ok(GetPropertyPrice);
        }


        [HttpPost( "Add", Name = "AddProperty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PropertyDTO> AddProperty(PropertyDTO newPropertyDTO)
        {
            //we validate the data here
            if (newPropertyDTO == null || newPropertyDTO.CountryID == -1 || newPropertyDTO.NumberOfBedrooms == -1 ||
                newPropertyDTO.NumberOfBathrooms == -1 ||
                string.IsNullOrEmpty(newPropertyDTO.City) || string.IsNullOrEmpty(newPropertyDTO.Address) ||
                newPropertyDTO.ContainerID == -1 || string.IsNullOrEmpty(newPropertyDTO.Name))
            {
                return BadRequest("Invalid Property data.");
            }

          

            PR_BusinessLayer.clsProperty property = new PR_BusinessLayer.clsProperty(new PropertyDTO(
                newPropertyDTO.PropertyID,
                newPropertyDTO.CountryID, newPropertyDTO.City, newPropertyDTO.Address,
                newPropertyDTO.PlaceDescription, newPropertyDTO.ContainerID,
                newPropertyDTO.NumberOfBedrooms
                , newPropertyDTO.NumberOfBathrooms, 
                newPropertyDTO.PropertyTypeID,
                newPropertyDTO.Price,
                newPropertyDTO.Name));
           
            
            property.Save();

            newPropertyDTO.PropertyID = property.PropertyID;

           
            return CreatedAtRoute("GetPropertyById", new { id = newPropertyDTO.PropertyID }, newPropertyDTO);

        }



       
        [HttpPut("UpdateProperty", Name = "UpdateProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PropertyDTO> UpdatedProperty(int Propertyid, PropertyDTO updatedProperty)
        {
            if (updatedProperty == null || updatedProperty.CountryID == -1 ||
                updatedProperty.NumberOfBedrooms == -1 ||
                updatedProperty.NumberOfBathrooms == -1 ||
                string.IsNullOrEmpty(updatedProperty.City) ||
                string.IsNullOrEmpty(updatedProperty.Address) ||
                updatedProperty.ContainerID == -1 ||
                string.IsNullOrEmpty(updatedProperty.Name)
                )
            {
                return BadRequest("Invalid Property data.");
            }
           

            PR_BusinessLayer.clsProperty Property = PR_BusinessLayer.clsProperty.Find(Propertyid);


            if (Property == null)
            {
                return NotFound($"Property with ID {Propertyid} not found.");
            }


            Property.Name = updatedProperty.Name;
            Property.CountryID = updatedProperty.CountryID;
            Property.NumberOfBedrooms = updatedProperty.NumberOfBedrooms;
            Property.NumberOfBathrooms = updatedProperty.NumberOfBathrooms;
            Property.City = updatedProperty.City;
            Property.Address = updatedProperty.Address;
            Property.Price = updatedProperty.Price;
            Property.PlaceDescription = updatedProperty.PlaceDescription;
            Property.ContainerID = updatedProperty.ContainerID;
            Property.PropertyTypeID = (sbyte)updatedProperty.PropertyTypeID;



            Property.Save();

           
            return Ok(Property.PDTO);

        }


       
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

          
            if (PR_BusinessLayer.clsProperty.DeleteProperty(id) != -1)

                return Ok($"Property with ID {id} has been deleted.");
            else
                return NotFound($"Property  with ID {id} not found. no rows deleted!");
        }



    }
}
