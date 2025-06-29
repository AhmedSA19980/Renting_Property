using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PR_DataAccessLayer;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {


        [HttpGet("All", Name = "Countries")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        //here we used StudentDTO
        public ActionResult<IEnumerable<CountryDTO>> GetAllProperties() // Define a method to get all students.
        {
           

            List<CountryDTO> countriesList = PR_BusinessLayer.clsCountry.ListAllCountries();
            if (countriesList.Count == 0)
            {
                return NotFound("Not a single  Country is Recroded in data!");
            }
            return Ok(countriesList); // Returns the list of countries.

        }


        [HttpGet("CountryName", Name = "CountryID")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

      
        public ActionResult<IEnumerable<int>> GetCountryName(string Name) // Define a method to get all students.
        {
           
            int countryID = PR_BusinessLayer.clsCountry.Find(Name).ID;
            if (countryID == -1)
            {
                return NotFound("Not a single  Country is Recroded in data!");
            }
            return Ok(countryID); 

        }

        [HttpGet("CountryNameByID", Name = "CountryName")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        
        public ActionResult<IEnumerable<string>> GetCountryNameByID(int CountryID) 
        {
            

            string countryName = PR_BusinessLayer.clsCountry.Find(CountryID).CountryName;
            if (countryName == "")
            {
                return NotFound("Not a single  Country is Recroded in data!");
            }
            return Ok(countryName); 

        }

    }
}
