using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Discount
    {
      
            public int DiscountID { get; set; }
            public int PropertyID { get; set; }
            public decimal DiscountPercentage { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public bool IsDeleted { get; set; }
        
    }
}
