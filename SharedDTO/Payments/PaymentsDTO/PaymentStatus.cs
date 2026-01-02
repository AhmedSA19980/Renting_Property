using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOLayer.Payments.PaymentsDTO
{
    public  class PaymentStatus
    {
       
        public string Id { get; set; }
        public string status {  get; set; }
        public string email { get; set; }
        public string Name { get; set; }

        public string Currency { get; set; }
        public string total { get; set; }
        public DateTime Created { get; set; }

    }
}
