using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Altinok.Azure.EventGrid
{
	public class EventGridTopicBuilder
	{
		public IServiceCollection Services { get; }

		public EventGridTopicBuilder(IServiceCollection services)
		{
			Services = services;
		}

		public IServiceCollection AddTopic<T>(T topic)
		where T : TopicConfiguration
		{
			return Services.AddSingleton(topic);
		}

		public IServiceCollection AddTopic<T>(IConfiguration configuration)
			where T : TopicConfiguration, new()

		{
			Services.Configure<T>(configuration);
			var topic = new T();
			configuration.Bind(topic);

			return AddTopic(topic);
		}
	}

}
