using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Reservation
    {
        public int BookID { get; set; }
        public int PropertyId { get; set; }
        public int BookedByClientId { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime BeginDate { get; set; }
        public bool IsBooked { get; set; }
    }
}
