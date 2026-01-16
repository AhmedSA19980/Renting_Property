using Stripe;


namespace PR_BusinessLayer.StripePayment
{
    public class clsStripeConfiguration
    {

        public static string ApiKey()
        {
            DotNetEnv.Env.Load();
            return StripeConfiguration.ApiKey = "sk_test_51IrXl7JvZibGlkkBpLuxOVaJH6ADE46nWRy8OoRrexYhVRmX32SlxQ3MHEv2Xol4Rm6kF3UYcbizKTIU6erhQsnd00hELBodTc";// Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY");
        }

    }
}
