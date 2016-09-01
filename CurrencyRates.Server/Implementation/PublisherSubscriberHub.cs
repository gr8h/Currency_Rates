using CurrencyRates.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace CurrencyRates.Service.Implementation
{
    static class PublisherSubscriberHub
    {
        static Dictionary<string, List<IPublishing>> Subscribers = new Dictionary<string, List<IPublishing>>();

        //Get list of subscriber filtered by the currency pair value
        static List<IPublishing> GetSubscribers(string currencyPair)
        {
            lock (typeof(PublisherSubscriberHub))
            {
                if (Subscribers.ContainsKey(currencyPair))
                {
                    return Subscribers[currencyPair];
                }
                else
                {
                    return new List<IPublishing>();
                }
            }
        }

        //Subscribe a client to a specific urrency pair value
        static public bool Subscribe(string currencyPair, IPublishing subscriberCallbackReference)
        {
            try
            {
                lock (typeof(PublisherSubscriberHub))
                {
                    //Check if currency pair exists
                    if (Subscribers.ContainsKey(currencyPair))
                    {
                        //Check if the client is already registerd to the currency pair or not
                        if (!Subscribers[currencyPair].Contains(subscriberCallbackReference))
                        {
                            Subscribers[currencyPair].Add(subscriberCallbackReference);
                        }
                    }
                    else
                    {
                        List<IPublishing> newSubscribersList = new List<IPublishing>();
                        newSubscribersList.Add(subscriberCallbackReference);
                        Subscribers.Add(currencyPair, newSubscribersList);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception
                return false;
            }
        }

        //UnSubscribe a client from a specific urrency pair value
        static public bool Unsubscribe(string currencyPair, IPublishing subscriberCallbackReference)
        {
            try
            {
                //Lock to handel conurency
                lock (typeof(PublisherSubscriberHub))
                {
                    if (Subscribers.ContainsKey(currencyPair))
                    {
                        if (Subscribers[currencyPair].Contains(subscriberCallbackReference))
                        {
                            Subscribers[currencyPair].Remove(subscriberCallbackReference);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception
                return false;
            }
        }

        //Notify all currency pair subscribers with the new update
        static public void Notify(PubSubMessage msg)
        {
            try
            {
                //Get subscribers
                var sublist = GetSubscribers(msg.CurrencyPairName);

                if (sublist == null) return;

                //Open threads equal to the number of subscribers
                sublist.AsParallel().ForAll(callback =>
                {
                    if (((ICommunicationObject)callback).State
                        == CommunicationState.Opened)
                    {
                        callback.Publish(msg);
                    }
                    else
                    {
                        sublist.Remove(callback);
                    }
                }
                );
            }
            catch (Exception ex)
            {
                //Log Exception
                throw ex;
            }
        }
    }
}
