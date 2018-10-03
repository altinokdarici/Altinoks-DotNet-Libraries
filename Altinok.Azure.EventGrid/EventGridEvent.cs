using Microsoft.Azure.EventGrid.Models;
using System;
namespace Altinok.Azure.EventGrid
{
	public class EventGridEvent<T> : EventGridEvent
	{
		private const string DefaultDataVersion = "2.0";

		public EventGridEvent(string id, string subject, T data, string eventType, DateTime eventTime, string dataVersion, string topic = null, string metadataVersion = null) : base(id, subject, data, eventType, eventTime, dataVersion, topic, metadataVersion)
		{
		}
		public EventGridEvent()
		{
			Id = Guid.NewGuid().ToString();
			EventTime = DateTime.UtcNow;
			DataVersion = DefaultDataVersion;
		}
		public new T Data => (T)base.Data;


	}

}
