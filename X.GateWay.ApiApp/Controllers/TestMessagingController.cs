﻿using System.Threading.Tasks;
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
        /// we will use RabbitMQ Message bus 
        /// </summary>
        private readonly IBusClient _BusClient;

        #endregion

        #region Constructor


        /// <summary>
        /// IOC will send to the controller instance of the BusClient
        /// </summary>
        /// <param name="BusClient"></param>
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
