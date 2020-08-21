using System;
using System.Collections.Generic;
using System.Text;
using RawRabbit.Configuration;


namespace X.Common.Helpers.MessageBus.BusClient.RawRabbit
{

	/// <summary>
	///helper class to hold the "connection string" to (RabitMq) message bus 
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
