using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOLayer.Earning
{
    public class AllOwnerEarningsByPropertyDTO
    {

        public int ClientID { get; set; }
        public int PropertyID { get; set; }

        public string CountryName { get; set; }
        public decimal Price { get; set; }
        public string DiscountPer { get; set; }
        public string Name { get; set; }
        public bool IsPropertyDeleted { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int BookingClientID { get; set; }

        public string PaymentStatus { get; set; }

        public decimal PricePerDay { get; set; }
        public decimal DiscountAfterPrice { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PaidDate { get; set; }

        public int BookingID { get; set; }


        public AllOwnerEarningsByPropertyDTO(int ClientID, int propertId, string countryName, decimal price, string discountPer, string name, bool isPropertyDeleted
              , DateTime startDate, DateTime endDate, int bookingByClientId, string paymentStatus, decimal pricePerDay,
              decimal PriceAfterDiscount, decimal totalAmount,
             DateTime paidDate, int bookingId)
        {
            this.ClientID = ClientID;
            PropertyID = propertId;
            CountryName = countryName;
            Price = price;
            DiscountPer = discountPer;
            Name = name;
            IsPropertyDeleted = isPropertyDeleted;
            StartDate = startDate;
            EndDate = endDate;
            BookingClientID = bookingByClientId;
            PaymentStatus = paymentStatus;
            PricePerDay = pricePerDay;
            DiscountAfterPrice = PriceAfterDiscount;
            TotalAmount = totalAmount;
            PaidDate = paidDate;
            BookingID = bookingId;


        }
    }
}