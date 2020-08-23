using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace Demo2.Common.Helpers.MessageBus
{
    /// <summary>
    /// singletone with singletone BusClient
    /// </summary>
    public class BusClientWrapper
    {
        #region Singletone

        public static readonly BusClientWrapper Instance = new BusClientWrapper();

        private BusClientWrapper()
        {

        }

        #endregion 

        #region properties

        private RawRabbit.vNext.Disposable.IBusClient BusClient { get; set; }

        #endregion


        #region public 

        public void Init()
        { 
            //step1: init RawRabbitConfiguration
            //       note: we can read it from config file https://rawrabbit.readthedocs.io/en/master/configuration.html
            var RawRabbitConfiguration = new RawRabbit.Configuration.RawRabbitConfiguration
            {
                Username = "guest",
                Password = "guest",
                Port = 5672,
                VirtualHost = "/",
                Hostnames = { "localhost" }
            };

            //step2: create client instance 
            //as soon as the client is instantiated, it wil ltry to connect to the broker
            RawRabbit.vNext.Disposable.IBusClient BusClient = RawRabbit.vNext.BusClientFactory.CreateDefault(RawRabbitConfiguration);


            //step3: save the singletone instance
            this.BusClient = BusClient;
        }


        public void PublishAsync<TMessage>(TMessage Message)
        {
            this.BusClient.PublishAsync(Message);
        }


        public void SubscribeAsync<TMessage>    (Func<TMessage, Task> handlerMethod)
        {
            this.BusClient.SubscribeAsync<TMessage>(
                    async (msg, context)
                    =>
                    {
                        await handlerMethod(msg);
                    }
            );
        }
       
        #endregion 
    }
}
