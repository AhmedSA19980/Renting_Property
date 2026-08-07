using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class CustomerCard
    {

        public int ID { get; set; }
        public string CardName { get; set; }
        public string CardNo { get; set; }
        public DateTime EstablishedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int ClientID { get; set; }
        public string CVV { get; set; }

    }
}
