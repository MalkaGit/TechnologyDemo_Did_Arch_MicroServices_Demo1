using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using X.Common.Messages.Common.Commands;
using X.Common.Messages.Common.Events;

namespace X.Common.Helpers.MessageBus.RabbitMQ
{
    public static class RabbitMqExtensions
    {

        /// <summary>
        /// async mwthod
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="bus"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        /// <remarks>
        /// accepts the bus, the command handler
        /// </remarks>
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







        /// <summary>
        /// init IOC to map IBusClient 
        /// to an instance of RawRabbit that takes its settings from rabbitmq secion on the appsettings.json
        /// </summary>
        /// <param name="services">
        /// the ioc collection defined in the Gatewat app (or ser micro service app) on StartUp.cs file   public void ConfigureServices(IServiceCollection services)
        /// </param>
        /// <param name="configuration">
        /// the content of te file appsettings.json
        /// </param>
        /// <remarks>
        /// </remarks>
        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            //step1: read the rabbitmq settings from appsettings.json
            var section = configuration.GetSection("rabbitmq"); //the rabbitmq section in the conffuration file: appsettings.json 
            var options = new RabbitMqOptions();
            //step2: rate instance of service bus RawRabbit that use that configuration

            section.Bind(options); //options will hols all the reabbit mq settings in the appsettings.json

            //step3: create instance of RawRabbit that implement IBusClient
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });

            //services collection is the IOc cnotainer
            //register the RawRabbit onthe ioc as IBusClient  (to publish and subscribe to any message bus)
            //note: we use dingletone becuase ew wnat the RawRabbit to mange the connection to to the message bus (rabbit mq)
            services.AddSingleton<IBusClient>(_ => client);//register to the IOC IBusClient that is instance of RawRabbit with the settings from the appsettings.json
        }
    }
}
