using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PR_BusinessLayer.StripePayment;
using PropertyRentingApi.Services;
using Stripe;
using Stripe.Checkout;
using StripePayment;

namespace PropertyRentingApi.Controllers
{
    // [Route("api/[controller]")]
    [Route("")]
    [ApiController]
    public class WebhookController : ControllerBase
    {

       private readonly StripeWebhookService _webhookService;

        private readonly IConfiguration _config;
        public WebhookController(StripeWebhookService webhookservice)
        {
            _webhookService = webhookservice;
       
        }


        [HttpPost("webhook" , Name ="webhook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
      
        public async Task<IActionResult> Handle()
        {

            try
            {
                // Read the raw body as string
                var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
                var signatureHeader = Request.Headers["Stripe-Signature"];

                await _webhookService.ProcessWebhookAsync(json, signatureHeader);

                
                // add save log payment

                
                return Ok(); // Always respond 200 if processed successfully


            }
            catch (StripeException e)
            {
                Console.WriteLine($"⚠️ Stripe exception: {e.Message}");
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine($"❌ Error processing webhook: {e}");
                return StatusCode(5);
            }


     

            return Ok();

        }

    }
}
