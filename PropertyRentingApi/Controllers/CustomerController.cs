using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PR_DataAccessLayer;
using Stripe;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet("getCustomerbyID", Name = "GetCustomerById")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetCustomerById(string  CustomerID)
        {
          


            if (string.IsNullOrEmpty(CustomerID))
            {

                return BadRequest($"Empty Field cannot be empty.");
            }
          
                var customer = await PR_BusinessLayer.Stripe.clsCustomer.RetrieveCustomer(CustomerID);
                if (customer == null)
                {
                    return NotFound($"Customer with ID {CustomerID} not found");
                }

                return Ok(customer);    
           
          
        }

        [HttpPost("AddCustomer" , Name ="AddCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCustomer(string email , string name)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name)) {

                return BadRequest("Email/Name Field Cannot be Empty!");
            
            }
            var customer  = await PR_BusinessLayer.Stripe.clsCustomer.CreateCustomer(email, name);
            return CreatedAtRoute("AddCustomer" , new {customer.Id });
        }



        [HttpPost("UpdateCustomer", Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCustomer(string customerid , string email, string name)
        {
            if (string.IsNullOrEmpty(customerid) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name))
            {

                return BadRequest("ID and Email/Name Field Cannot be Empty!");

            }
            var customer = await PR_BusinessLayer.Stripe.clsCustomer.UpdateCustomer(customerid , email, name);
            return Ok(customer);
        }

        [HttpDelete("DeleteCustomer", Name = "RemoveCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteCustomer(string CustomerID)
        {
            if (string.IsNullOrEmpty(CustomerID))
            {
                return BadRequest("Customer ID cannot be empty !");
            }

            var customer = await PR_BusinessLayer.Stripe.clsCustomer.DeleteCustomer(CustomerID);
            if (customer != null)
            {
               
                return Ok($"Customer with{CustomerID} Removed Successfully !");
            }
            return NotFound($"Customer  with ID {CustomerID} is not found !");
        }
    }
}
