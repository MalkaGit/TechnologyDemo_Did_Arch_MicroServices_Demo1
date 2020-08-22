using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using X.Common.Messages.Common.Commands;
using X.Common.Messages.Common.Events;

namespace X.Common.Helpers.MessageBus.BusClient.RawRabbit
{

    public static class RabbitMqExtensions
    {
        ///<summary>
        ///configure the IOC container with details of how to create and initalize an instance of RawRabbit.IBusClient
        ///</summary>
        ///<param name="services">the IOC container that commes from ASP.Net core </param>
        ///<param name="configuration">the configuration object that holds the settings from appsettings.json file </param>
        ///<usage>
        ///1.   Any application that interacts with (RabbitMq) service bus has to
        ///     call this method from  ConfigureServices(IServiceCollection services) on Startup.
        ///         eg:
        ///         public void ConfigureServices(IServiceCollection services)
        ///         {   ...
        ///             //Added:
        ///             services.AddRabbitMq(Configuration);
        ///             ...    
        ///         }
        ///2.   Any class that interacts with (RabbitMq) service bus has to
        ///     define a constructor that accepts (fromm IOC) IBusClient and saves it as data member
        /// 
        ///         #region properties 
        ///         <summary>
        ///         interface for communicating with the (RabbitMq) message bus
        ///         </summary>
        ///         <remarks>
        ///         1   this is an instance of Rbabbit.IBusClient
        ///         2.  Startup.js calls the AddRabbitMq method to tell the IOC how to create the IBusClient.
        ///         3.  the IBusClient takes its settings from rabbitmq  section on appsettings.json
        ///         </remarks>
        ///         private readonly IBusClient _BusClient;
        ///         #endregion
        ///
        ///         #region Constructor
        ///         <summary>
        ///         IOC will send the IBusClient instance argummnent
        ///         </summary>
        ///         <param name="BusClient"></param>
        ///         <remarks>
        ///         1.  Startup.js calls the AddRabbitMq method to tell the IOC how to create the IBusClient.
        ///         </remarks>
        ///         public TestMessagingController(IBusClient BusClient)
        ///         {
        ///             this._BusClient = BusClient;
        ///         }
        ///         #endregion 
        /// </usage>
        /// <remarks>
        /// 1.  the IBusClient read its settings from rabbitmq section in appsettings.json
        /// 2.  we use singletone istance !!!  of the IBusClient
        ///     we use singletone becuase we wnat the RawRabbit to mange the connection to to the message bus (rabbit mq)
        /// </remarks>
        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            //step1: read the rabbitmq section from appsettings.json
            var section = configuration.GetSection("rabbitmq");

            //step2: load the settings from the rabbitmq sections into the the RabbitMqOptions (settings model) 
            var options = new RabbitMqOptions();
            section.Bind(options);


            //step3: create  instance of RawRabbit.BusClient  (sngletone !!!) 
            //TODO: Log
            var client = RawRabbitFactory.CreateSingleton(
                new RawRabbitOptions    {ClientConfiguration = options});


            //step4: configure IOC to map RawRabbit.IBusClient to RawRabbit.BusClient (sngletone !!!)
            services.AddSingleton<IBusClient>(_ => client);
        }

























        /// <summary>
        /// TODO: review - video 9
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="bus"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static Task WithCommandHandlerAsync<TCommand>
        (
            this IBusClient bus,
            ICommandHandler<TCommand> handler
        ) where TCommand : ICommand
            =>
            bus.SubscribeAsync<TCommand>(
                msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumerConfiguration(
                                                        cfg =>
                                                        cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))
                                                    )
                );





        /// <summary>
        /// TODO: review - video 9
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="bus"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static Task WithEventHandlerAsync<TEvent>
        (
            this IBusClient bus,
            IEventHandler<TEvent> handler
       ) where TEvent : IEvent
            =>
            bus.SubscribeAsync<TEvent>(
                msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumerConfiguration(
                                                        cfg =>
                                                        cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))
            )
        );





        private static string GetQueueName<T>()
            =>
            $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

    }
}
