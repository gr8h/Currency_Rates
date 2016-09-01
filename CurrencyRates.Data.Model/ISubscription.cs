using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates.Model
{
    [ServiceContract(CallbackContract = typeof(IPublishing))]
    public interface ISubscription
    {
        [OperationContract]
        bool Subscribe(string currencyPair);

        [OperationContract]
        bool UnSubscribe(string currencyPair);
    }
}
