using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using X.Common.Messages.Common.Commands;
using X.Common.Messages.Common.Events;



namespace X.Common.Helpers._1RabbitMQ
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







        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            services.AddSingleton<IBusClient>(_ => client);
        }
    }


}
