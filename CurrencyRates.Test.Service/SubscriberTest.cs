using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyRates.Model;
using System.Configuration;
using System.ServiceModel;
using System.Collections.Generic;

namespace CurrencyRates.Test.Service
{
    [TestClass]
    public class SubscriberTest: IPublishing
    {
        private ISubscription _SubProxy;
        public SubscriberTest()
        {
            _SubProxy = CreateSubProxy();
        }

        [TestMethod]
        public void SubscribeTest()
        {
            //Arrange
            string pairName = "EURO_USD";

            //Act
            var res = _SubProxy.Subscribe(pairName);
            //Assert
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void UnSubscribeTest()
        {
            //Arrange
            string pairName = "EURO_USD";

            //Act
            var res = _SubProxy.UnSubscribe(pairName);

            //Assert
            Assert.IsTrue(res);
        }

        #region Helpers
        private ISubscription CreateSubProxy()
        {
            string endpointAddressInString = ConfigurationManager.AppSettings["EndpointAddressSubscriber"];

            NetTcpBinding netTcpbinding = new NetTcpBinding(SecurityMode.None);
            EndpointAddress endpointAddress = new EndpointAddress(endpointAddressInString);
            InstanceContext context = new InstanceContext(this);

            DuplexChannelFactory<ISubscription> channelFactory = new DuplexChannelFactory<ISubscription>(new InstanceContext(this), netTcpbinding, endpointAddress);
            return channelFactory.CreateChannel();
        }

        public void Publish(PubSubMessage msg)
        {
            
        }
        #endregion
    }
}
