using Lab8.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;

namespace Lab8.Services.Implementations
{
    internal class DropBoxReferModule : IDropBoxReferModule
    {
        private readonly IServiceProvider _provider;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public DropBoxReferModule(IServiceProvider provider)
        {
            _provider = provider;
            _httpClientFactory = _provider.GetService<IHttpClientFactory>()!;
            _config = _provider.GetService<IConfiguration>()!;
        }

        private string _token;

        public string Token
        {
            get { return _token; }
            private set { _token = value; }
        }

        public string ReferToBrowser =>
            $"https://www.dropbox.com/oauth2/authorize?client_id={_config.GetSection("app_key").Value}&response_type=code";

        public async Task<bool> oAuth2Token(string key)
        {
            var client = _httpClientFactory?.CreateClient();
            HttpStatusCode reply = HttpStatusCode.NotFound;

			var content = new FormUrlEncodedContent(new[]
			{
				new KeyValuePair<string, string>("code", key),
				new KeyValuePair<string, string>("grant_type", "authorization_code"),
				new KeyValuePair<string, string>("client_id", _config.GetSection("app_key").Value),
				new KeyValuePair<string, string>("client_secret",  _config.GetSection("app_secret").Value),
			});

			var response = await client!.PostAsync($"https://api.dropboxapi.com/oauth2/token", content);

            if(response.StatusCode is not HttpStatusCode.OK)
            {
				return false;
			}

			string jsonstr = await response.Content.ReadAsStringAsync();
            JsonObject finallyObj = JsonObject.Parse(jsonstr)!.AsObject();
            _token = finallyObj["access_token"]!.GetValue<string>();

			reply = response.StatusCode;

            return true;
        }
    }
}
