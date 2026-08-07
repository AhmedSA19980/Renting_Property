using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class PaymentDetail
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
    }
}
