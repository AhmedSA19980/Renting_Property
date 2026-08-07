using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PaymentSession
    {
        [JsonProperty("url")]
        public  string url { get; set; }
        public string idempotencyKey { get; set; }
      
    }
}
