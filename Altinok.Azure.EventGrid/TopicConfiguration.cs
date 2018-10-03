namespace Altinok.Azure.EventGrid
{
	public abstract class TopicConfiguration
	{
		public string TopicEndPoint { get; set; }
		public string SasKey { get; set; }
	}
}
