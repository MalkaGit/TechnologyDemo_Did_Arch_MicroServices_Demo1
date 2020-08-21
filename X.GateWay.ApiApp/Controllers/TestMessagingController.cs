using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using X.Common.Messages.MessagingTest;

namespace X.GateWay.ApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestMessagingController : ControllerBase
    {
        #region properties 

        /// <summary>
        /// interface for communicating with the (RabbitMq) message bus
        /// </summary>
        /// <remarks>
        /// 1   this is an instance of Rbabbit.IBusClient
        /// 2.  Startup.js calls the AddRabbitMq method to tell the IOC how to create the IBusClient.
        /// 3.  the IBusClient takes its settings from rabbitmq  section on appsettings.json
        /// </remarks>
        private readonly IBusClient _BusClient;

        #endregion

        #region Constructor


        /// <summary>
        /// IOC will send the IBusClient instance argummnent
        /// </summary>
        /// <param name="BusClient"></param>
        /// <remarks>
        /// 1.  Startup.js calls the AddRabbitMq method to tell the IOC how to create the IBusClient.
        /// </remarks>
        public TestMessagingController(IBusClient BusClient)
        {
            this._BusClient = BusClient;
        }

        #endregion 


       
        /// <summary>
        /// Test the publish commnad
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] TestMessagingCommand command)
        {
         
            await this._BusClient.PublishAsync(command);

            return Accepted();
        }

    }




}
