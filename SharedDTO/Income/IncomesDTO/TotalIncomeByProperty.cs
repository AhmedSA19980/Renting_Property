using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOLayer.Income.IncomesDTO
{
    public class TotalIncomeByProperty
    {
        public decimal TotalIncome { get; set; }    
        public TotalIncomeByProperty(decimal totalIncome) {
        
            this.TotalIncome = totalIncome; 
        }
    }
}
