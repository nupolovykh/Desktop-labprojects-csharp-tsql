using Lab8.Models;
using Lab8.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Windows.Automation.Provider;

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

		private string token;

		public string Token
		{
			get { return token; }
			private set { token = value; }
		}

		public string ReferToBrowser =>
			$"https://www.dropbox.com/oauth2/authorize?client_id={_config.GetSection("app_key").Value}&response_type=code";

		public async Task<bool> oAuth2Token(string key)
		{
			var client = _httpClientFactory?.CreateClient();

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
			Token = finallyObj["access_token"]!.GetValue<string>();

			return true;
		}

		public async Task<List<FolderModel>> GetFoldersTree()
		{
			var client = _httpClientFactory?.CreateClient();

			client!.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
			client!.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var data = new
			{
				include_deleted = false,
				include_has_explicit_shared_members = false,
				include_media_info = false,
				include_mounted_folders = true,
				include_non_downloadable_files = true,
				path = "",
				recursive = false
			};

			var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client!.PostAsync("https://api.dropboxapi.com/2/files/list_folder", content);

			Stream stream = await response.Content.ReadAsStreamAsync();
			var jdata = JsonSerializer.Deserialize<JsonObject>(stream)!;

			JsonArray entries = jdata["entries"]!.AsArray();

			if (entries == null) return null!;

			var filter = entries.Where(e =>
			{
				var jobj = e as JsonObject;
				if (jobj != null && jobj.TryGetPropertyValue(".tag", out var tagValue))
				{
					return tagValue!.ToString() == "folder";
				}
				return false;
			});

			int numberId = 0;
			List<FolderModel> folders = filter!.Select<JsonNode, FolderModel>(f =>
			{
				return new FolderModel
				{
					Id = numberId++,
					Name = f["name"]!.ToString(),
					Path = f["path_display"]!.ToString()
				};
			}).ToList()!;

			return folders;
		}
	}
}
