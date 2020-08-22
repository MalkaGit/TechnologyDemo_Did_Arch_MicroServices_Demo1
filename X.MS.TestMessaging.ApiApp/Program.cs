using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using X.Common.Messages.MessagingTest;
using X.Common.Helpers.ServiceHost;

namespace X.MS.TestMessaging.ApiApp
{
    public class Program
    {
        #region original Net Core 
        /*
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

         public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        */

        #endregion

        public static void Main(string[] args)
        {
            ServiceHost
                .Create<Startup>(args)                          //returns service host
                .UseRabbitMq()                                  //return bus builder
                .SubscribeToCommand<TestMessagingCommand>()     //use ioc to create instance of the handler and tell the bus to handle the coommands with that hadker
                .Build()
                .Run();
        }


    }
}
