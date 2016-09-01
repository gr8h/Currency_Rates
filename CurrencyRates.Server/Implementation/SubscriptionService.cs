using System;
using System.Collections.Generic;
using System.ServiceModel;
using CurrencyRates.Model;

namespace CurrencyRates.Service.Implementation
{
    public class SubscriptionService : ISubscription
    {
        public bool Subscribe(string currencyPair)
        {
            IPublishing subscriber = OperationContext.Current.GetCallbackChannel<IPublishing>();
            return PublisherSubscriberHub.Subscribe(currencyPair, subscriber); ;
        }

        public bool UnSubscribe(string currencyPair)
        {
            IPublishing subscriber = OperationContext.Current.GetCallbackChannel<IPublishing>();
            return PublisherSubscriberHub.Unsubscribe(currencyPair, subscriber); ;
        }
    }
}
