using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PaymentLog
    {
        public int ID { get; set; }
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
