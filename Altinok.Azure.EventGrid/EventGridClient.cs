using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altinok.Azure.EventGrid
{
	/// <summary>
	/// Event Grid client to send events
	/// </summary>
	public class EventGridClient<T> : IEventGridClient<T>
		where T : TopicConfiguration
	{
		private readonly TopicConfiguration configuration;
		private static TopicCredentials topicCredentials;
		private static EventGridClient client;
		private static string topicHostname;
		public EventGridClient(T configuration)
		{
			this.configuration = configuration;
			topicCredentials = new TopicCredentials(configuration.SasKey);
			topicHostname = new Uri(configuration.TopicEndPoint).Host;
			client = new EventGridClient(topicCredentials);
		}

		/// <summary>
		/// Send one event to a topic
		/// </summary>
		/// <param name="gridEvent">Event to send</param>
		public Task SendAsync(EventGridEvent gridEvent)
		{
			return SendAsync(new EventGridEvent[] { gridEvent });
		}

		/// <summary>
		/// Send multiple events to a topic
		/// </summary>
		/// <param name="events">Events to send</param>
		public Task SendAsync(IList<EventGridEvent> events)
		{
			return client.PublishEventsAsync(topicHostname, events);
		}

	}

}
