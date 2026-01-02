using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOLayer.Payments.PaymentsDTO
{
    public class AddPaymentDTO
    {
      
            public AddPaymentDTO( DateTime startDate, DateTime endDate, decimal pricePerDay, decimal totalAmount, int clientID, int propertyID,
                int carID, byte status, decimal returnAmount, string note, DateTime returnDate, DateTime paidDate, int BookingID)
            {

               
                this.StartDate = startDate;
                this.EndDate = endDate;
                this.PricePerDay = pricePerDay;
               // this.TotalAmount = totalAmount;
                this.ClientID = clientID;
                this.PropertyID = propertyID;
                this.CardID = carID;
            
              
                this.PaidDate = paidDate;
                this.BookingID = BookingID;
            }
            //public int ID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public decimal PricePerDay { get; set; }
        //    public decimal TotalAmount { get; set; }

            public int ClientID { get; set; }
            public int PropertyID { get; set; }
            public int CardID { get; set; }



            public DateTime PaidDate { get; set; }

            public int BookingID { get; set; }
        }
    
}
