using System;
using System.Threading.Tasks;
using GettingStarted.ConsoleApp.Messages;

namespace GettingStarted.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            PUbSub().Wait();

            Console.ReadLine();
        }



        static async Task PUbSub()
        {
            //https://rawrabbit.readthedocs.io/en/master/Getting-started.html#instance-from-factory

            //Create a new client by calling BusClientFactory.CreateDefault. 
            //If no arguments are provided, the local configuration will be used (guest user on localhost:5672 with virtual host /).


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
            var client = RawRabbit.vNext.BusClientFactory.CreateDefault(RawRabbitConfiguration);



            //step4: subscribe
            //SubscribeAsync gets one parameter called subscribedMethod of type Func<TMessage,TMessageContext,Task>
            //subscribedMethod is the method that will be invoked when the message is recieved.
            //subscribedMethod gets the Message (of type T) and context
            //subscribedMethod returns void 
            client.SubscribeAsync<XMessage>(
                    async (msg, context)
                    =>
                    {
                        Console.WriteLine($"Recieved: {msg.param1}.");
                    }
            );

            //step5: publish
            //PublishAsync gets one parameter called message of type T
            //PublishAsync retruns void
            await client.PublishAsync(new XMessage { param1 = "Hello, world!" });


        }

     
    }
}
