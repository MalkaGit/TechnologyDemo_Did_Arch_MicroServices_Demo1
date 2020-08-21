using System;
using System.Collections.Generic;
using System.Text;
using RawRabbit.Configuration;


namespace X.Common.Helpers.MessageBus.BusClient.RawRabbit
{

	/// <summary>
	///holds the settings  to connect to the (RabbitMq) message bus from bus client 
	/// </summary>
	/// <remarks>
	/// 1.	the settings comes from  appsettings.json file (rabbitmq sectinos).
	///2.	every porject that communicate with the service bus
	///		defiee these settings in its appsettings.json.
	///		eg:		X.GateWay.ApiApp, 
	///				X.MS.Activities.Api.App,X.MS.Identity.ApiApp, X.MS.TestMessaging    
	/// </remarks>
	public class RabbitMqOptions : RawRabbitConfiguration
    {
    }
}
