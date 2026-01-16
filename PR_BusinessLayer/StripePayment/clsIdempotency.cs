using System;
using Stripe;

namespace PR_BusinessLayer.StripePayment
{
    public class clsIdempotencyHelper
    {
        public static RequestOptions GetIdempotentRequestOpetions() {

            return new RequestOptions()
            {

                IdempotencyKey = Guid.NewGuid().ToString()
            };
        }   

    }
}
