using Microsoft.Extensions.DependencyInjection;
using System;

namespace Altinok.Azure.EventGrid
{
	public static class Extension
	{
		public static IServiceCollection AddEventGrid(this IServiceCollection serviceCollection, Action<EventGridTopicBuilder> topicBuilder)
		{
			serviceCollection.AddScoped(typeof(IEventGridClient<>), typeof(EventGridClient<>));
			topicBuilder(new EventGridTopicBuilder(serviceCollection));

			return serviceCollection;
		}


	}

}
