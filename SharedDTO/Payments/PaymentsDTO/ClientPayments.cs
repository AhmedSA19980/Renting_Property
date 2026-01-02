using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOLayer.Payments.PaymentsDTO
{
    public class ClientPayments
    {
       
            public int ID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal PricePerDay { get; set; }
            public decimal TotalAmount { get; set; }

            public string PropertyTypeName { get; set; }
            public string PropertyName { get; set; }

            public string PaymentStatus { get; set; }

            public string Note { get; set; }
            public DateTime? PaidDate { get; set; }

            public int BookingID { get; set; }
            public int ClientID { get; set; }

        public ClientPayments(
       int id,
       DateTime startDate,
       DateTime endDate,
       decimal pricePerDay,
       decimal totalAmount,
       string propertyTypeName,
       string propertyName,
       string paymentStatus,
       string note,
       DateTime? paidDate,
       int bookingID,
       int clientID
   )
        {
            ID = id;
            StartDate = startDate;
            EndDate = endDate;
            PricePerDay = pricePerDay;
            TotalAmount = totalAmount;
            PropertyTypeName = propertyTypeName;
            PropertyName = propertyName;
            PaymentStatus = paymentStatus;
            Note = note;
            PaidDate = paidDate;
            BookingID = bookingID;
            ClientID = clientID;
        }
    }

    
}
