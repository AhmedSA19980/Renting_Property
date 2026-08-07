using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AllEarningsByProperty
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

    }
}
