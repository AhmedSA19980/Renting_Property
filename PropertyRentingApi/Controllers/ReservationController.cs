using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PR_BusinessLayer;
using SharedDTOLayer.Books.BooksDTO;
using System.Security.Claims;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {


        [HttpGet("GetReservationById", Name = "GetReservationById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingDTO> GetReservationById(int BookId)
        {
            if (BookId < 1)
            {
                return BadRequest($"Not accepted ID {BookId}");
            }

          

            PR_BusinessLayer.clsBooking Book = PR_BusinessLayer.clsBooking.Find(BookId);

            if (Book == null)
            {
                return NotFound($"Student with ID {BookId} not found.");
            }

            
            BookingDTO PDTO = Book.BDTO;

            return Ok(PDTO);

        }




        [Authorize]
        [HttpPost("Add", Name = "AddBook")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<BookingUpsertDTO> AddBook([FromBody]BookingUpsertDTO ReservationDTO)
        {
            // note leave (price) field as it is !
            
            if (ReservationDTO == null ||ReservationDTO.PropertyId ==-1 || ReservationDTO.BookedByClientId ==-1 ||
                ReservationDTO.ExpiredDate == default(DateTime) || ReservationDTO.BeginDate == default(DateTime)
                
                )
            {
                return BadRequest("Invalid Reservation data.");
            }

            if (ReservationDTO.BeginDate < DateTime.Now || ReservationDTO.ExpiredDate < DateTime.Now) { 
                return BadRequest("St Date/Exp Date cannot be in the past 1");
            }

            PR_BusinessLayer.clsProperty PropertyPrice = PR_BusinessLayer.clsProperty.Find(ReservationDTO.PropertyId);

            PR_BusinessLayer.clsBooking reserve = new PR_BusinessLayer.clsBooking(new BookingUpsertDTO(ReservationDTO.BookID,ReservationDTO.PropertyId
                ,ReservationDTO.BookedByClientId ,PropertyPrice.Price , ReservationDTO.ExpiredDate , ReservationDTO.BeginDate));
            
            if(ReservationDTO.PropertyId == 0 || ReservationDTO.BookedByClientId == 0)
            {
                return BadRequest("Invalid PropertyID/ClientId");
            }
            
           
           PR_BusinessLayer.clsDiscount DiscountProp= PR_BusinessLayer.clsDiscount.GetDiscountsByPropertyID(ReservationDTO.PropertyId);
            
            
            if (DiscountProp != null  && DiscountProp.EndDate > DateTime.Now) {
                decimal PriceAfterOffer = clsDiscount.ImplementDiscount(ReservationDTO.PropertyId);
                reserve.Price= PriceAfterOffer;
             
            }
            

            reserve.Save();
            ReservationDTO.BookID = reserve.BookID;
            ReservationDTO.Price = reserve.Price;
          
            
            
            
            return CreatedAtRoute("AddBook", new { id = ReservationDTO.BookID }, ReservationDTO);
        }


        [HttpGet("getActiveReservationDate", Name = "getActiveReservationDate")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<CheckForActiveReservationDTO> CheckActiveReservationDate(int PropertyId , DateTime stDate , DateTime exDate)
        {

            if (PropertyId < 0)
            {

                return BadRequest($"Not accepted ID {PropertyId}");
            }

            var ActiveReservationDate = PR_BusinessLayer.clsBooking.CheckForActiveReservationDate(PropertyId, stDate ,exDate);
            if (ActiveReservationDate == null)
            {
                return NotFound($"Book with ID {PropertyId} not found or No Valid Offer is exist for this Property.");
            }

            return Ok(ActiveReservationDate);
        }
        [Authorize]
        [HttpPut("UpdateReservationDate", Name = "UpdateReservationDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<BookingUpsertDTO> UpdateReservationDate(BookingUpdateDTO ReservationDTO)
        {
            if (ReservationDTO == null || ReservationDTO.ExpiredDate == default(DateTime) || ReservationDTO.BeginDate == default(DateTime))
            {
                return BadRequest("Invalid student data.");
            }

            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            int clientReservation = PR_BusinessLayer.clsBooking.Find(ReservationDTO.BookID).BookedByClientId;

            if (Convert.ToInt32(userIdStr) != clientReservation) return Unauthorized("you're Unauthorized to update this Reservation");




            PR_BusinessLayer.clsBooking reserve = PR_BusinessLayer.clsBooking.Find(ReservationDTO.BookID);
            if (reserve == null )
            {
                return BadRequest("Invalid Reservation ID");
            }


            reserve.BookID = ReservationDTO.BookID;
            reserve.ExpiredDate = ReservationDTO.ExpiredDate;
            reserve.BeginDate = ReservationDTO.BeginDate;


            reserve.Save();

            
            return Ok(reserve.BUDTO);

        }

        [Authorize]
        [HttpDelete("DeleteReservation", Name = "DeleteReservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult DeleteReservationType(int BookId)
        {
            if (BookId < 1)
            {
                return BadRequest($"Not accepted ID {BookId}");
            }

            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            int clientReservation = PR_BusinessLayer.clsBooking.Find(BookId).BookedByClientId;

            if (Convert.ToInt32(userIdStr) != clientReservation) return Unauthorized("you're Unauthorized to delete this Reservation");



            if (PR_BusinessLayer.clsBooking.DeleteBooking(BookId) != -1)

                return Ok($"Book  with ID {BookId} has been deleted.");
            else
                return NotFound($"Book with ID {BookId} not found. no rows deleted!");
        }



    }
}
