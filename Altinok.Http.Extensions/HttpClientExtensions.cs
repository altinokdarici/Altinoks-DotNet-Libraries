using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Altinok.Http.Extensions
{
	public static class HttpClientExtensions
	{

		/// <summary>
		///     Send a GET request to the specified Uri and deserialize the json response body as a <typeparamref name="T"/>
		///     in an asynchronous operation.
		/// </summary>
		/// <typeparam name="T"></typeparam>	 
		/// <param name="httpClient"></param>
		/// <param name="requestUri"></param>
		/// <returns></returns>
		public static async Task<T> GetAsync<T>(this HttpClient httpClient, string requestUri)
		{
			var json = await httpClient.GetStringAsync(requestUri);
			var result = JsonConvert.DeserializeObject<T>(json);

			return result;
		}

		/// <summary>
		///     Send a GET request and deserialize the json response body as a <typeparamref name="T"/>
		///     in an asynchronous operation.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="httpClient"></param>
		/// <param name="requestUri"></param>
		/// <returns></returns>
		public static Task<T> GetAsync<T>(this HttpClient httpClient) => httpClient.GetAsync<T>(string.Empty);
	}
}
