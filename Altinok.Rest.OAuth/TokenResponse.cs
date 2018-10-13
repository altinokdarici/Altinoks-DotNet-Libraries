using Newtonsoft.Json;

namespace Altinok.Rest.OAuth
{
	internal class TokenResponse
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("expires_in")]
		public int ExpiresIn { get; set; }

		[JsonProperty("token_type")]
		public string TokenType { get; set; }
	}
}
