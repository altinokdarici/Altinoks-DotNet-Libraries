using Microsoft.Rest;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Altinok.Rest.OAuth
{
	public class OAuthTokenProvider : ITokenProvider
	{
		private static HttpClient httpClient;
		private static readonly object syncRoot = new object();
		private readonly string tokenEndpoint;
		private readonly string grantType;
		private readonly IEnumerable<KeyValuePair<string, string>> properties;

		public OAuthTokenProvider(string tokenEndpoint, string grantType, IEnumerable<KeyValuePair<string, string>> properties)
		{
			this.tokenEndpoint = tokenEndpoint;
			this.grantType = grantType;
			this.properties = properties;
		}
		public async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
		{
			if (httpClient == null)
			{
				lock (syncRoot)
				{
					if (httpClient == null)
					{
						httpClient = new HttpClient();
					}
				}
			}

			var payload = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("grant_type", grantType)
			};
			payload.AddRange(properties);


			var content = new FormUrlEncodedContent(properties);
			using (var response = await httpClient.PostAsync(tokenEndpoint, content))
			{
				response.EnsureSuccessStatusCode();
				var json = await response.Content.ReadAsStringAsync();
				var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(json);

				return new AuthenticationHeaderValue(tokenResponse.TokenType, tokenResponse.AccessToken);

			}
		}

	}
}
