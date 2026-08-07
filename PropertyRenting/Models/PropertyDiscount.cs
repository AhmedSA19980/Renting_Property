using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class PropertyDiscount
    {
        public int DiscountID { get; set; }
        public int PropertyID { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompeleted { get; set; }


      
        public string CountryName { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public decimal Price { get; set; }
        public bool IsPropertyDeleted { get; set; }
    }
}
