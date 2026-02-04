using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedDTOLayer.Offer.DiscountDTO;
using System.Security.Claims;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        [HttpGet("getDicountbyID", Name = "GetDiscountById")] 
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

        [HttpGet("getActiveDicountbyPropertyID", Name = "getActiveDicountbyPropertyID")] 
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
                return NotFound($"There's no active offer with propertyID= {PropertyID}");
            }
            
            

            return Ok(ActiveDiscount);
        }


        [HttpGet("GetAllPropertyDicounts", Name = "GetDiscountsByPropertyId")] 
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
                return NotFound($"Offers with property  {PropertyID}= ID are empty.");
            }

            return Ok(discounts);
        }



        [HttpGet("GetAllDiscountsBelongToAproperty", Name = "GetAllDiscountsBelongToAproperty")] 
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
                return NotFound($"No Offers are found  for this {PropertyID} !");
            }

            return Ok(discounts);
        }



        [HttpGet("GetDiscountID", Name = "GetDiscountID")] 
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
                return NotFound($"Offer with ID {GetDiscountID} not found.");
            }

            return Ok(GetDiscountID);
        }


        [Authorize] 
        [HttpPost("AddDiscountToProperty", Name = "AddDiscountToProperty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DiscountDTO> AddDiscountToProperty(int PropertyID, decimal PrecentOff, string StartDate, string EndDate)
        {
            DiscountDTO DiscountDTO = new DiscountDTO();
      


            if ( PropertyID == -1 ||
                PrecentOff == 0 || StartDate == "" || EndDate =="")//default(DateTime)
            {
                return BadRequest("Invalid Discount data.");
            }


              var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
              int PropertyOwner = PR_BusinessLayer.clsPropertyOwner.GetPropertyClientIdByPropertyID(PropertyID);

              if (Convert.ToInt32(userIdStr) != PropertyOwner) return Unauthorized("you're  Unauthorized to add  Offer!");
            

            //start date must set like 2025-08-19
            PR_BusinessLayer.clsDiscount Discount =  PR_BusinessLayer.clsProperty.PropertyPricePrecentOFF(PropertyID , PrecentOff , StartDate  ,EndDate);
            

            
            DiscountDTO.DiscountID = Discount.DiscountID;
            DiscountDTO.PropertyID = Discount.PropertyID;
            DiscountDTO.StartDate = Discount.StartDate;
            DiscountDTO.DiscountPercentage = Discount.DiscountPercentage;
            DiscountDTO.EndDate = Discount.EndDate;
            DiscountDTO.IsDeleted = Discount.IsDeleted;
           
            return CreatedAtRoute("AddDiscountToProperty", new { id = DiscountDTO.DiscountID }, DiscountDTO);


        }


        [Authorize]
        [HttpPut("UpdateDiscontById", Name = "UpdateDiscount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DiscountDTO> UpdateDiscount( DiscountDTO DiscountDTO)
        {

            if (DiscountDTO == null || DiscountDTO.PropertyID == -1 ||
                DiscountDTO.DiscountPercentage == 0 || DiscountDTO.StartDate == default(DateTime) || DiscountDTO.EndDate == default(DateTime))
            {
                return BadRequest("Invalid Discount data.");
            }


            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            int PropertyOwner = PR_BusinessLayer.clsPropertyOwner.GetPropertyClientIdByPropertyID(DiscountDTO.PropertyID);

            if (Convert.ToInt32(userIdStr) != PropertyOwner) return Unauthorized("you're you're  Unauthorized to update this Offer!");


            PR_BusinessLayer.clsDiscount Discount = PR_BusinessLayer.clsDiscount.Find(DiscountDTO.DiscountID);


            Discount.DiscountID = DiscountDTO.DiscountID;
            Discount.PropertyID = DiscountDTO.PropertyID;
            Discount.DiscountPercentage = DiscountDTO.DiscountPercentage;
            Discount.StartDate = DiscountDTO.StartDate;
            Discount.EndDate = DiscountDTO.EndDate;
            Discount.Save();

            

            return Ok(Discount.DDTO);


        }


        
        [Authorize]
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
            var propertyID = PR_BusinessLayer.clsDiscount.Find(CancelOfferById).PropertyID;
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            int PropertyOwner = PR_BusinessLayer.clsPropertyOwner.GetPropertyClientIdByPropertyID(propertyID);

            if (Convert.ToInt32(userIdStr) != PropertyOwner) return Unauthorized("you're you're  Unauthorized to delete this Offer!");


            if (PR_BusinessLayer.clsDiscount.DeleteDiscountOffer(CancelOfferById) != -1)

                return Ok($"Offer with ID {CancelOfferById} has been deleted.");
            else
                return NotFound($"Offer with ID {CancelOfferById} not found!");
        }

    }
}
