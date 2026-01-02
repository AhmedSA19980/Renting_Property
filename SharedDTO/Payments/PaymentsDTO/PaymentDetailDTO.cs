using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOLayer.Payments.PaymentsDTO
{
    public class PaymentDetailDTO
    {
            public int Id { get; set; }

            public string CountryName { get; set; }

            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public decimal OriginalPrice { get; set; }

            // Comes from CASE expression: '0%' or '10%'
            public string DiscountPer { get; set; }

            public decimal PricePerDay { get; set; }
            public decimal TotalAmount { get; set; }

            public string PropertyTypeName { get; set; }
            public string Name { get; set; }

            public string PaymentStatus { get; set; }

            public string Note { get; set; }

            public DateTime? PaidDate { get; set; }

            public int BookingID { get; set; }

            public int BookedByClientId { get; set; }

        public PaymentDetailDTO(
       int id,
       string countryName,
       DateTime startDate,
       DateTime endDate,
       decimal originalPrice,
       string discountPer,
       decimal pricePerDay,
       decimal totalAmount,
       string propertyTypeName,
       string Name,
       string paymentStatus,
       string note,
       DateTime? paidDate,
       int bookingID,
       int bookedByClientId)
        {
            this.Id = id;
            this.CountryName = countryName;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.OriginalPrice = originalPrice;
            this.DiscountPer = discountPer;
            this.PricePerDay = pricePerDay;
            this.TotalAmount = totalAmount;
            this.PropertyTypeName = propertyTypeName;
            this.Name = Name;
            this.PaymentStatus = paymentStatus;
            this.Note = note;
            this.PaidDate = paidDate;
            this.BookingID = bookingID;
            this.BookedByClientId = bookedByClientId;
        }

    }
}
