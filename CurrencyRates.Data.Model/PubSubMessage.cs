using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates.Model
{
    [DataContract]
    public class PubSubMessage
    {
        [DataMember]
        public string CurrencyPairName { get; set; }

        [DataMember]
        public string CurrencyPairData { get; set; }
    }
}
