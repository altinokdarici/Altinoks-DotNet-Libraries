using Microsoft.Azure.EventGrid.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altinok.Azure.EventGrid
{
	public interface IEventGridClient<T>
		where T : TopicConfiguration
	{
		Task SendAsync(EventGridEvent gridEvent);
		Task SendAsync(IList<EventGridEvent> events);
	}
}
