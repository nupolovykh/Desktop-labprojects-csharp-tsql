using Lab8.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            set { _token = value; }
        }

        public bool GetAuth()
        {
            var loginClient = _httpClientFactory?.CreateClient();
            string appkey = _config.GetSection("app_key").Value;
            HttpStatusCode reply = HttpStatusCode.NotFound;

            var task = Task.Run(async () =>
            {
                Trace.WriteLine($"https://www.dropbox.com/oauth2/authorize?client_id={appkey}&response_type=code");
                var response = await loginClient!.GetAsync($"https://www.dropbox.com/oauth2/authorize?client_id={appkey}&response_type=code");
                Trace.WriteLine(response);

                //Token = response.Content.

                //var stringContent = new FormUrlEncodedContent(new[]
                //{
                //    new KeyValuePair<string, string>("field1", "value1"),
                //    new KeyValuePair<string, string>("field2", "value2"),
                //});

                //await loginClient!.PostAsync($"https://api.dropboxapi.com/oauth2/token", stringContent);

                reply = response.StatusCode;
            });

            if (reply == HttpStatusCode.OK) return true;

            return false;
        }
    }
}
