using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo2.Common.Helpers.MessageBus;
using Demo2.Common.Messages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Demo2.Sub.ApiApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            using (FileStream fs = File.Create(@"c:\todel\f2.txt"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            Configuration = configuration;

            BusClientWrapper.Instance.Init();
            BusClientWrapper.Instance.SubscribeAsync<XMessage>(async (msg) =>
           {
               using (FileStream fs = File.Create(@"c:\todel\" +DateTime.UtcNow.Ticks.ToString() ))
               {
                   byte[] info = new UTF8Encoding(true).GetBytes("got message");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
               }

           });
                
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
