using Microsoft.Extensions.Configuration;
using SharedDTOLayer.Payments.PaymentsDTO;
using Stripe;
using Stripe.Checkout;

namespace StripePayment
{
    public class clsPayment
    {



        private readonly string _secretKey;

        public clsPayment(IConfiguration config)
        {
            _secretKey = config["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _secretKey;
        }

        public static async Task<(string Url, string IdempotencyKey)> CreateCheckoutSessionAsync(PaymentRequest payment)
        {
            var idempotencyKey = Guid.NewGuid().ToString();

            var options = new SessionCreateOptions
            {
               
                //*"https://yourapp.com/success?session_id={CHECKOUT_SESSION_ID}",
                PaymentMethodTypes = new List<string> { "card" },
                Mode = "payment",
                SuccessUrl =  "https://localhost:7042/api/Payment/payment/success?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://yourapp.com/cancel",
                Metadata = new Dictionary<string, string>{
                                   { "BookID", payment.BookID.ToString() }
                               },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Quantity = 1,
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            UnitAmount = (long)(payment.Price * 100),
                          
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                              // Description =$"ref property{payment.Id}",
                              
                                Name = payment.PropertyName,
                            }
                        }
                      
                    }
                }
                
               
            };

            var service = new SessionService();
            var requestOptions = new RequestOptions
            {
                IdempotencyKey = idempotencyKey
            };

            var session = await service.CreateAsync(options, requestOptions);

            return (session.Url, idempotencyKey);
        }

    }
}