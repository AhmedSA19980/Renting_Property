using System;
using Stripe;
using DotNetEnv;

namespace PR_BusinessLayer.StripePayment
{
    public  class clsCustomer
    {


        public static async Task<Customer> CreateCustomer(string email, string name)
        {
           
            try
            {
                var Opetion = new CustomerCreateOptions
                {
                    Email = email,
                    Name = name
                };

                var service = new CustomerService();
                var RequestOpetions = clsIdempotencyHelper.GetIdempotentRequestOpetions();


                Customer customer = service.Create(Opetion , RequestOpetions);
              

                return customer;    
            }
            catch (Exception ex) {
            
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public static async Task<Customer>   RetrieveCustomer(string customerID)
        {
            try
            {
                var service = new CustomerService();
              //  var RequestOpetions = clsIdempotencyHelper.GetIdempotentRequestOpetions();

                Customer customer = service.Get(customerID );// 
                return customer;
            }
            catch (StripeException ex)
            {
                Console.WriteLine($"Stripe Error: {ex.Message}");
                switch (ex.StripeError.Type)
                {
                    case "invalid_customer_id":
                        Console.WriteLine("Invalid Customer ID provided.");
                        break;
                }
                return null;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
           
        }


        public static async Task<Customer> UpdateCustomer(string customerID, string email , string name) {


            try
            {
                var options = new CustomerUpdateOptions
                {
                    Email = email,
                    Name = name,


                };

                var service = new CustomerService();
                var RequestOpetions = clsIdempotencyHelper.GetIdempotentRequestOpetions();

                Customer customer = service.Update(customerID, options , RequestOpetions);
                return customer;
            }
            catch (StripeException ex) {

                Console.WriteLine($"Stripe Error: {ex.Message}");
                switch (ex.StripeError.Type)
                {
                    case "invalid_customer_id":
                        Console.WriteLine("Invalid Customer ID provided.");
                        break;
                    case "invalid_card_number":
                        Console.WriteLine("Invalid card number.");
                        break;
                    case "invalid_expiry_month":
                        Console.WriteLine("Invalid expiry month.");
                        break;
                    case "invalid_expiry_year":
                        Console.WriteLine("Invalid expiry year.");
                        break;
                    case "invalid_cvc":
                        Console.WriteLine("Invalid CVC.");
                        break;
                    case "card_declined":
                        Console.WriteLine("Card declined.");
                        // You might want to get the decline code for more details:
                        if (ex.StripeError.DeclineCode != null)
                        {
                            Console.WriteLine($"Decline code: {ex.StripeError.DeclineCode}");
                        }
                        break;
                    case "incorrect_number":
                        Console.WriteLine("Incorrect card number.");
                        break;
                    case "incorrect_cvc":
                        Console.WriteLine("Incorrect CVC.");
                        break;
                    case "expired_card":
                        Console.WriteLine("Expired card.");
                        break;
                }
                
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                return null; // Or throw
            }


        }

        public static async Task< bool> DeleteCustomer(string CustomerID) {
            try
            {
                var service = new CustomerService();
                //var RequestOpetions = clsIdempotencyHelper.GetIdempotentRequestOpetions();
                ////no need for idempotent key in case of deleting customer// it does not result in muliple delettion of a customer

                Customer customer = service.Delete(CustomerID );
                return true;
            }
            catch (StripeException ex)
            {
                switch (ex.StripeError.Type)
                {
                    case "invalid_customer_id":
                        Console.WriteLine("Invalid Customer ID provided.");
                        break;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
