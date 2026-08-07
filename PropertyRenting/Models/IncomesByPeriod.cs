using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class IncomesByPeriod
    {
        public decimal TotalIncome { get; set; }
        public decimal Fee { get; set; }
        public decimal Tax { get; set; }

        public decimal NetAfterTaxAndFee { get; set; }
    }
}
