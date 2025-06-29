using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PR_BusinessLayer;
using PR_DataAccessLayer;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        [HttpGet("getDicountbyID", Name = "GetDiscountById")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<DiscountDTO>> GetDicountById(int DicountID)
        {

            if (DicountID < 0)
            {

                return BadRequest($"Not accepted ID {DicountID}");
            }

            PR_BusinessLayer.clsDiscount discount = PR_BusinessLayer.clsDiscount.Find(DicountID);
            if (discount == null)
            {
                return NotFound($"Discount with ID {DicountID} not found.");
            }

            DiscountDTO DDTO = discount.DDTO;

            return Ok(DDTO);
        }

        [HttpGet("getActiveDicountbyPropertyID", Name = "getActiveDicountbyPropertyID")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<int> getActiveDicountbyPropertyID(int PropertyID)
        {

            if (PropertyID < 0)
            {

                return BadRequest($"Not accepted ID {PropertyID}");
            }

            int ActiveDiscount = PR_BusinessLayer.clsProperty.FindActiveDiscountByID(PropertyID);
            if (ActiveDiscount == -1)
            {
                return NotFound($"Property with ID {PropertyID} not found or No Valid Offer is exist for this Property.");
            }

            

            return Ok(ActiveDiscount);
        }


        [HttpGet("GetAllPropertyDicounts", Name = "GetDiscountsByPropertyId")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<List<DiscountDTO>> GetDiscountsBy(int PropertyID)
        {

            if (PropertyID < 0)
            {

                return BadRequest($"Not accepted ID {PropertyID}");
            }

            List<DiscountDTO> discounts = PR_BusinessLayer.clsDiscount.GetAllDiscountsByPropertyID(PropertyID);
            if (discounts == null)
            {
                return NotFound($"Property with ID {PropertyID} not found.");
            }

            return Ok(discounts);
        }



        [HttpGet("GetAllDiscountsBelongToAproperty", Name = "GetAllDiscountsBelongToAproperty")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<List<PropertyDiscountDTO>> GetAllDiscountsBelongToAproperty(int PropertyID)
        {

            if (PropertyID < 0)
            {

                return BadRequest($"Not accepted ID {PropertyID}");
            }

            List<PropertyDiscountDTO> discounts = PR_BusinessLayer.clsDiscount.FindAllDiscountBelongToAPropertyByPropertyID(PropertyID);
            if (discounts == null)
            {
                return NotFound($"Property with ID {PropertyID} not found.");
            }

            return Ok(discounts);
        }






        [HttpPost("AddDiscount", Name = "AddDiscount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DiscountDTO> AddDiscount(DiscountDTO DiscountDTO)
        {
            //we validate the data here
            if (DiscountDTO == null || DiscountDTO.PropertyID == -1 ||
                DiscountDTO.DiscountPercentage == 0 || DiscountDTO.StartDate == default(DateTime) || DiscountDTO.EndDate == default(DateTime))
            {
                return BadRequest("Invalid Discount data.");
            }

           
            PR_BusinessLayer.clsDiscount Discount = new PR_BusinessLayer.clsDiscount(new DiscountDTO(DiscountDTO.DiscountID, DiscountDTO.PropertyID,
                DiscountDTO.DiscountPercentage, DiscountDTO.StartDate, DiscountDTO.EndDate, DiscountDTO.IsDeleted));
            Discount.Save();

            DiscountDTO.DiscountID = Discount.DiscountID;

          

            return CreatedAtRoute("AddDiscount", new { id = DiscountDTO.DiscountID }, DiscountDTO);


        }



        [HttpGet("GetDiscountID", Name = "GetDiscountID")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<int> GetPropertyId(int DiscountID)
        {

            if (DiscountID < 0)
            {

                return BadRequest($"Not accepted ID {DiscountID}");
            }

            int GetDiscountID = PR_BusinessLayer.clsDiscount.Find(DiscountID).DiscountID;
            if (GetDiscountID == 0)
            {
                return NotFound($"Property with ID {GetDiscountID} not found.");
            }

            return Ok(GetDiscountID);
        }



        [HttpPost("AddDiscountToProperty", Name = "AddDiscountToProperty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DiscountDTO> AddDiscountToProperty(int PropertyID, decimal PrecentOff, string StartDate, string EndDate)
        {
            DiscountDTO DiscountDTO = new DiscountDTO();
            //we validate the data here
            if ( PropertyID == -1 ||
                PrecentOff == 0 || StartDate == "" || EndDate =="")//default(DateTime)
            {
                return BadRequest("Invalid Discount data.");
            }

        
            PR_BusinessLayer.clsDiscount Discount =  PR_BusinessLayer.clsProperty.PropertyPricePrecentOFF(PropertyID , PrecentOff , StartDate  ,EndDate);
            Discount.Save();

            DiscountDTO.DiscountID = Discount.DiscountID;

            

            return CreatedAtRoute("AddDiscount", new { id = DiscountDTO.DiscountID }, DiscountDTO);


        }

        [HttpPut("UpdateDiscontById", Name = "UpdateDiscount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DiscountDTO> UpdateDiscount(int DiscontId, DiscountDTO DiscountDTO)
        {
            //we validate the data here
            if (DiscountDTO == null || DiscountDTO.PropertyID == -1 ||
                DiscountDTO.DiscountPercentage == 0 || DiscountDTO.StartDate == default(DateTime) || DiscountDTO.EndDate == default(DateTime))
            {
                return BadRequest("Invalid Discount data.");
            }

          
            PR_BusinessLayer.clsDiscount Discount = PR_BusinessLayer.clsDiscount.Find(DiscontId);
          

            Discount.DiscountID = DiscountDTO.DiscountID;
            Discount.PropertyID = DiscountDTO.PropertyID;
            Discount.DiscountPercentage = DiscountDTO.DiscountPercentage;
            Discount.StartDate = DiscountDTO.StartDate;
            Discount.EndDate = DiscountDTO.EndDate;
            Discount.Save();

          
            return Ok(Discount.DDTO);


        }


        //here we use HttpDelete method
        [HttpDelete("Cancel/{CancelOfferById}", Name = "CancelOfferById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> CancelOfferById(int CancelOfferById)
        {
            if (CancelOfferById < 1)
            {
                return BadRequest($"Not accepted ID {CancelOfferById}");
            }

           
            if (PR_BusinessLayer.clsDiscount.DeleteDiscountOffer(CancelOfferById) != -1)

                return Ok($"Property with ID {CancelOfferById} has been deleted.");
            else
                return NotFound($"Property with ID {CancelOfferById} not found. no rows deleted!");
        }

    }
}
