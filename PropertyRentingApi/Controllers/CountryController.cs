using Microsoft.AspNetCore.Mvc;
using SharedDTOLayer.Countries.CountriesDTO;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {


        [HttpGet("All", Name = "Countries")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

      
        public ActionResult<IEnumerable<CountryDTO>> GetAllProperties() 
        {
            
            List<CountryDTO> countriesList = PR_BusinessLayer.clsCountry.ListAllCountries();
            if (countriesList.Count == 0)
            {
                return NotFound("Not a single  Country is Recroded in data!");
            }
            return Ok(countriesList); 

        }


        [HttpGet("CountryName", Name = "CountryID")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public ActionResult<IEnumerable<int>> GetCountryName(string Name) 
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
