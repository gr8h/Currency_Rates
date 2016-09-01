using CurrencyRates.Model;
using CurrencyRates.Service;
using CurrencyRates.Service.Implementation;
using System;
using System.Configuration;
using System.ServiceModel;

namespace CurrencyRates.Host
{
    class Program
    {
        static ServiceHost _publishServiceHost = null;
        static ServiceHost _subscribeServiceHost = null;
        static void Main(string[] args)
        {
            try
            {
                HostPublishService();
                HostSubscriptionService();

                Console.WriteLine("Subscribtion and Publisher services started successfully.");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void HostSubscriptionService()
        {
            string endpointAddressSubscriber = ConfigurationManager.AppSettings["EndpointAddressSubscriber"];

            _subscribeServiceHost = new ServiceHost(typeof(SubscriptionService));
            NetTcpBinding tcpBinding = new NetTcpBinding(SecurityMode.None);

            _subscribeServiceHost.AddServiceEndpoint(typeof(ISubscription), tcpBinding, endpointAddressSubscriber);
            _subscribeServiceHost.Open();
        }

        private static void HostPublishService()
        {
            string endpointAddressPublisher = ConfigurationManager.AppSettings["EndpointAddressPublisher"];

            _publishServiceHost = new ServiceHost(typeof(PublishingService));
            NetTcpBinding tcpBindingpublish = new NetTcpBinding();

            _publishServiceHost.AddServiceEndpoint(typeof(IPublishing), tcpBindingpublish, endpointAddressPublisher);
            _publishServiceHost.Open();
        }
    }
}
