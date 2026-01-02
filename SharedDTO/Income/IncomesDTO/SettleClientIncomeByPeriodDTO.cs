using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOLayer.Income.IncomesDTO
{
    public  class SettleClientIncomeByPeriodDTO
    {

        public decimal TotalIncome { get; set; }
        public decimal Fee { get; set; }
        public decimal Tax { get; set; }

        public decimal NetAfterTaxAndFee { get; set; }


        public SettleClientIncomeByPeriodDTO (decimal totalIncome , decimal fee , decimal tax , decimal netAfterTaxAndFee)
        {
            this.TotalIncome = totalIncome;
            this.Fee = fee;
            this.Tax = tax;
            this.NetAfterTaxAndFee = netAfterTaxAndFee;
        }
    }
}
