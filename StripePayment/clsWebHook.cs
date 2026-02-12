using Stripe;
using Microsoft.Extensions.Configuration;
using Stripe.Checkout;

namespace PropertyRentingApi.Services
{
    public class StripeWebhookService
    {
        private readonly IConfiguration _config;

        public StripeWebhookService(IConfiguration config)
        {
            _config = config;
        }

        public async Task ProcessWebhookAsync(string json, string signatureHeader)
        {
            var webhookSecret = _config["Stripe:WebhookSecret"];
            Event stripeEvent;

            try
            {
                stripeEvent = EventUtility.ConstructEvent(
                    json,
                    signatureHeader,
                    webhookSecret,
                    throwOnApiVersionMismatch: false
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Webhook signature verification failed: {ex.Message}");
                throw;
            }

            switch (stripeEvent.Type)
            {
                case "checkout.session.completed":
                    var session = stripeEvent.Data.Object as Session;
                    await HandleCheckoutSessionCompletedAsync(session);
                  
                    break;

                case "payment_intent.succeeded":
                    var intent = stripeEvent.Data.Object as PaymentIntent;
                    await HandlePaymentIntentSucceededAsync(intent);
                    break;

                case "payment_intent.payment_failed":
                    var failedIntent = stripeEvent.Data.Object as PaymentIntent;
                    await HandlePaymentFailedAsync(failedIntent);
                    break;

                default:
                    Console.WriteLine($"⚠️ Unhandled event type: {stripeEvent.Type}");
                    break;
            }
        }

        private Task HandleCheckoutSessionCompletedAsync(Session session)
        {
            Console.WriteLine($"✅ Checkout completed for session {session?.Id}, customer: {session?.CustomerEmail} ");
            var resid = session!.Metadata["BookID"];
            Console.WriteLine($"metadata reservation id ->{resid}");
            
            StripePayment.savePayment.PaymentLog(Convert.ToInt32( resid) ,session.Created   );
           
            // Example: save payment to DB, mark order as paid, send email, etc.
            return Task.CompletedTask;
        }

        private Task HandlePaymentIntentSucceededAsync(PaymentIntent intent)
        {
            Console.WriteLine($"💰 PaymentIntent succeeded: {intent?.Id}, Amount: {intent?.AmountReceived / 100.0} {intent?.Currency}");
            // Example: save payment record or update transaction status
            return Task.CompletedTask;
        }

        private Task HandlePaymentFailedAsync(PaymentIntent intent)
        {
            Console.WriteLine($"❌ Payment failed: {intent?.Id}, Reason: {intent?.LastPaymentError?.Message}");
            return Task.CompletedTask;
        }
    }
}

