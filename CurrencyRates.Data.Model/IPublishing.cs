
using CurrencyRates.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates.Model
{
    [ServiceContract]
    public interface IPublishing
    {
        [OperationContract(IsOneWay = true)]
        void Publish(PubSubMessage msg);
    }
}
