using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using X.Common.Helpers._1RabbitMQ;
using X.Common.Messages.Common.Commands;
using X.Common.Messages.Common.Events;


namespace X.Common.Helpers._2ServiceHost
{


    public class ServiceHost : IServiceHost
    {
        #region Properties

        private readonly IWebHost _webHost;

        #endregion

        #region Constructor

        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }

        #endregion

        #region Public IServiceHost
        
        /// <summary>
        /// Euns the web host
        /// </summary>
        public void Run()
        {
            //Run the web host
            _webHost.Run();
        }

        #endregion


        #region Factory method returning factory for ServiceHost

        /// <summary>
        /// </summary>
        /// <typeparam name="TStartup"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>

        public static HostBuilder Create<TStartup>(string[] args) where TStartup : class
        {
            //set the console title
            Console.Title       = typeof(TStartup).Namespace;

            //creates configuraration for the web host
            var config          = new ConfigurationBuilder()
                                        .AddEnvironmentVariables()
                                        .AddCommandLine(args)
                                        .Build();

            //create the webhost builder
            var webHostBuilder  = WebHost.CreateDefaultBuilder(args)
                                        .UseConfiguration(config)
                                        .UseStartup<TStartup>();

            return new HostBuilder(webHostBuilder.Build());
        }

        #endregion








        #region nested Builder (factory) classes


        /// <summary>
        /// abstract class for factories of ServiceHost
        /// </summary>
        public abstract class BuilderBase
        {

            /// <summary>
            /// factory method
            /// </summary>
            /// <returns></returns>
            public abstract ServiceHost Build();
        }








        /// <summary>
        /// factory of Service host
        /// providers additional method to congigure the host to usre Service Bus (using Rabbit MQ)
        /// </summary>
        public class HostBuilder : BuilderBase
        {

            #region private Properties 

            private readonly IWebHost   _webHost;

            /// <summary>
            /// responsible for connecting to RabbitMQ bus , publishing and subscribing to it
            /// </summary>
            private IBusClient          _bus;

            #endregion


            #region Constructor


            public HostBuilder(IWebHost webHost)
            {
                _webHost = webHost;
            }

            #endregion


            #region Public methods 


            /// <summary>
            /// takes the IbusClient from the IOC and returns a bus builder
            /// supports any type of bus (defined bty IOC _webHost.Services)
            /// </summary>
            /// <returns></returns>
            public BusBuilder UseRabbitMq()
            {

                //note: !!!!
                ////    in the API projects (GW, Activities etc) we have Startup.cs with ConfigureServices method/
                ///     here we init the services (IOC)
                ///     
                ///     eg, in the GW project we define the services of the IOC container
                ///     public void ConfigureServices(IServiceCollection services)
                ///     {
                ///         services.AddMvc();
                ///         services.AddJwt(Configuration);
                ///         services.AddRabbitMq(Configuration);
                ///         services.AddMongoDB(Configuration);
                ///         services.AddScoped<IEventHandler<ActivityCreated>, ActivityCreatedHandler>();
                ///         services.AddScoped<IActivityRepository, ActivityRepository>();
                ///     }
                //      int the line:           _bus = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));
                ///                             we take the service that implemetns IBusClient 
                _bus = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));            //looks for service service that implements busClient that we registered to the IOC in ConfigureServices method 
                return new BusBuilder(_webHost, _bus);
            }


            /// <summary>
            /// Creates a ServiceHost
            /// </summary>
            /// <returns></returns>
            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }


           

            #endregion

        }











        /// <summary>
        /// factory class for creating ServiceHost.
        /// providers additional method to congigure the host to usre Service Bus (using Rabbit MQ)
        /// providers additional method to subscribe to revieve enents and commnads 
        /// </summary>
        public class BusBuilder : BuilderBase
        {
            #region Private Properties

            private readonly IWebHost   _webHost;
            private IBusClient          _bus;

            #endregion


            #region Public Constructor

            public BusBuilder(IWebHost webHost, IBusClient bus)
            {
                _webHost    = webHost;
                _bus        = bus;
            }

            #endregion




            #region Public methods 

            /// <summary>
            /// factory method for creating a ServiceHost       that may use ServiceBus (using RabbitMQ)
            /// </summary>
            /// <returns></returns>
            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }




            /// <summary>
            /// fluent API to subscribe to a command
            /// </summary>
            /// <typeparam name="TCommand"></typeparam>
            /// <returns></returns>
            public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
            {
                var handler =   (ICommandHandler<TCommand>)
                                _webHost.Services.GetService(typeof(ICommandHandler<TCommand>));   //resolve IOC: which concrete class was defied on IOC for this Tcommand
                            
                _bus.WithCommandHandlerAsync(handler); //using extention method 

                return this;    //return this to allow fluent api
            }


            /// <summary>
            /// fluent API to subscribe to an event
            /// </summary>
            /// <typeparam name="TEvent"></typeparam>
            /// <returns></returns>
            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                var handler =   (IEventHandler<TEvent>)
                                _webHost.Services.GetService(typeof(IEventHandler<TEvent>));     //resolve IOC: which concrete class was defied on IOC for this Tcommand   

                _bus.WithEventHandlerAsync(handler);    //using extention method 

                return this;    //return this to allow fluent api
            }

            #endregion

        }


        #endregion

        
    }
}
