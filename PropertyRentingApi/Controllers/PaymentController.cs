
using Microsoft.AspNetCore.Mvc;
using PR_BusinessLayer;
using PR_BusinessLayer.StripePayment;
using SharedDTOLayer.Books.BooksDTO;
using SharedDTOLayer.Payments.PaymentsDTO;
using SharedDTOLayer.Properties_.PropertiesDTO;
using Stripe;
using Stripe.Checkout;
using StripePayment;


namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {


        [HttpGet("GetAllPaymentsByClientID", Name = "GetAllPaymentsByClientID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<ICollection<ClientPayments>> GetAllPaymentsByClientID(int ClientID)
        {

            if (ClientID < 0)
            {

                return BadRequest($"Not accepted ID {ClientID}");
            }

            ICollection<ClientPayments> Payments = PR_BusinessLayer.clsPayments.GetAllClientPayments(ClientID);
            if (Payments.Count == 0)
            {
                return NotFound($"Payments Records with client ID {ClientID} is Empty/invalid clientid ! .");
            }

            return Ok(Payments);
        }

        [HttpGet("GetPaymentDetailByBookingId", Name = "GetPaymentDetailByBookingId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<PaymentDetailDTO> GetPaymentDetailByBookingId(int BookingId)
        {

            if (BookingId < 0)
            {

                return BadRequest($"Not accepted ID {BookingId}");
            }

            PaymentDetailDTO Payments = PR_BusinessLayer.clsPayments.PaymentDetail(BookingId);
            if (Payments == null)
            {
                return NotFound($"Payment Record with booking ID {BookingId} is Empty/invalid ! .");
            }

            return Ok(Payments);
        }



        [HttpPost("CreateCheckoutSessionAsync")]
        public  async Task<IActionResult> CreateCheckoutSessionAsync([FromBody] PaymentRequest request)
        {
            //  PR_BusinessLayer.StripePayment.clsStripeConfiguration.ApiKey();

            if (request == null || request.BookID == -1 || request.Price == 0 || string.IsNullOrEmpty(request.PropertyName)) {
                return BadRequest("please Make Sure to provide valid property data !");
            }
            clsBooking book = PR_BusinessLayer.clsBooking.Find(request.BookID);
            if (book == null)return BadRequest("reservaion id is not exit !");
               
            
            var (url, idempotencyKey) = await clsPayment.CreateCheckoutSessionAsync(request);
            return Ok(new { url, idempotencyKey });



        }


        [HttpGet("payment/success")]
        public IActionResult PaymentSuccess([FromQuery] string session_id)
        {
            return Ok($"Payment completed successfully. Session ID: {session_id}");
        }

        [HttpGet("status/{sessionId}")]
        public async Task<IActionResult> GetPaymentStatus(string sessionId)
        {
            var service = new SessionService();
            var session = await service.GetAsync(sessionId);
            var total = session.AmountTotal / 100m;
            return Ok(new {
                session.PaymentStatus, 
                session.Id , 
                total,
               session.CustomerDetails.Email,
                session.CustomerDetails.Name,
                session.Currency ,
                session.Created,
                session.Metadata
            
            });
        }



        [HttpPost("confirm-payment-intent")]
        public async Task<IActionResult> ConfirmPaymentIntent(string PaymentID)
        {
            PR_BusinessLayer.StripePayment.clsStripeConfiguration.ApiKey();
            var opetions = new PaymentIntentConfirmOptions
            {
               
                PaymentMethod = "pm_card_visa",//"pm_card_authenticationRequired",
                ReturnUrl = "https://localhost:7042/swagger/index.html"




            };
            var service = new PaymentIntentService();
            var PaymentIntent = service.Confirm(PaymentID, opetions);

            return Ok(opetions);
        }
    }
}
