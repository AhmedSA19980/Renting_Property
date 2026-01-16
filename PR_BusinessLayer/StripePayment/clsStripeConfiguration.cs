using Stripe;


namespace PR_BusinessLayer.StripePayment
{
    public class clsStripeConfiguration
    {

        public static string ApiKey()
        {
            DotNetEnv.Env.Load();
            return StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY");
        }

    }
}
