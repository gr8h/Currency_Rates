using CurrencyRates.Model;

namespace CurrencyRates.Service.Implementation
{
    public class PublishingService : IPublishing
    {
        public void Publish(PubSubMessage msg)
        {
            PublisherSubscriberHub.Notify(msg);
        }
    }
}
