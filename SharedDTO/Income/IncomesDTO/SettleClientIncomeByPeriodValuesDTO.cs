using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOLayer.Income.IncomesDTO
{
    public  class SettleClientIncomeByPeriodValuesDTO
    {
        public int ClientId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }


        public SettleClientIncomeByPeriodValuesDTO(int clientId , DateOnly startDate , DateOnly endDate) { 
        
            this.ClientId = clientId;
            this.StartDate = startDate;
            this.EndDate = endDate;

        }
    }
}
