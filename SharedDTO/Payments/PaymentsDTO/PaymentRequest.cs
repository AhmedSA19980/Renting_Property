using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOLayer.Payments.PaymentsDTO
{
    public  class PaymentRequest
    {

        
        public string PropertyName { get; set; }
        public decimal Price { get; set; }
        public int BookID { get; set; }
        public PaymentRequest(string propertyName , decimal price , int BookID) {
        
         
            PropertyName = propertyName;
            Price = price;
            this.BookID = BookID;


        }

    }
}
