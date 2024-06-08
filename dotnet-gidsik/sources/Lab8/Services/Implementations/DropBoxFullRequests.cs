using Lab8.Models;
using Lab8.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

public enum GetFoldersInType
{
	newFolder,
	navFolder
}

namespace Lab8.Services.Implementations
{
	internal class DropBoxFullRequests : IDropBoxGateway
	{
		private readonly IServiceProvider _provider;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _config;

		public DropBoxFullRequests(IServiceProvider provider)
		{
			_provider = provider;
			_httpClientFactory = _provider.GetService<IHttpClientFactory>()!;
			_config = _provider.GetService<IConfiguration>()!;
		}

		private string currentPath;
		public string CurrentPath
		{
			get { return currentPath; }
			private set { currentPath = value; }
		}

		private string token;
		public string Token
		{
			get { return token; }
			private set { token = value; }
		}

		private List<string> FileHistory { get; } = new List<string>();
		private int currentFileHistoryIndex = -1;

		// inteface required logic

		// http

		public string ReferToBrowser =>
			$"https://www.dropbox.com/oauth2/authorize?client_id={_config["app_key"]}&response_type=code";

		public async Task<bool> oAuth2Token(string key)
		{
			var client = _httpClientFactory?.CreateClient();

			var content = new FormUrlEncodedContent(new[]
			{
				new KeyValuePair<string, string>("code", key),
				new KeyValuePair<string, string>("grant_type", "authorization_code"),
				new KeyValuePair<string, string>("client_id", _config["app_key"]),
				new KeyValuePair<string, string>("client_secret",  _config["app_secret"]),
			});

			var response = await client!.PostAsync($"https://api.dropboxapi.com/oauth2/token", content);

			if (response.StatusCode is not HttpStatusCode.OK)
			{
				return false;
			}

			string jsonstr = await response.Content.ReadAsStringAsync();
			JsonObject finallyObj = JsonObject.Parse(jsonstr)!.AsObject();
			Token = finallyObj["access_token"]!.GetValue<string>();

			return true;
		}

		private async Task<List<FileModel>> PostRequestForListOfFiles(string source)
		{
			var data = new
			{
				include_deleted = false,
				include_has_explicit_shared_members = false,
				include_media_info = false,
				include_mounted_folders = true,
				include_non_downloadable_files = true,
				path = source,
				recursive = false
			};

			var client = _httpClientFactory?.CreateClient();

			client!.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
			client!.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client!.PostAsync("https://api.dropboxapi.com/2/files/list_folder", content);

			Stream stream = await response.Content.ReadAsStreamAsync();
			var jdata = JsonSerializer.Deserialize<JsonObject>(stream)!;

			int numberId = 0;
			return jdata["entries"]!.AsArray()!.Select<JsonNode, FileModel>(f =>
			{
				return new FileModel
				{
					Id = numberId++,
					Name = f["name"]!.ToString(),
					Type = f[".tag"]!.ToString(),
					Path = f["path_display"]!.ToString()
				};
			}).ToList()!;
		}

		public async Task<List<FileModel>> GetFoldersIn(GetFoldersInType navType, string? path = "")
		{
			List<FileModel> files = null!;

			switch (navType)
			{
				case GetFoldersInType.newFolder:
					if (path == string.Empty) ReturnToRoot();
					else if (FileHistory.Count > ++currentFileHistoryIndex) CutBackTheList();
					FileHistory.Add(path!);

					goto default;

				case GetFoldersInType.navFolder:
					goto default;

				default:
					files = await PostRequestForListOfFiles(path!);
					break;
			}

			//handler of server error => uninspected logic
			if (files is null && navType == GetFoldersInType.navFolder)
			{
				FileHistory.RemoveAt(currentFileHistoryIndex);
				return await GoToThePrev();
			}

			CurrentPath = path!;
			return files!;
		}

		public async Task<List<FileModel>> UpdateTheSnapshot()
		{
			return await GetFoldersIn(GetFoldersInType.navFolder, CurrentPath);
		}

		// navigation

		public bool CanGoPrev => currentFileHistoryIndex > 0;

		public Task<List<FileModel>> GoToThePrev()
		{
			return GetFoldersIn(GetFoldersInType.navFolder, FileHistory[--currentFileHistoryIndex]);
		}

		public bool CanGoNext => currentFileHistoryIndex < FileHistory.Count - 1;

		public Task<List<FileModel>> GoToTheNext()
		{
			return GetFoldersIn(GetFoldersInType.navFolder, FileHistory[++currentFileHistoryIndex]);
		}

		// implementation hidden logic

		private void ReturnToRoot()
		{
			currentFileHistoryIndex = 0;
			FileHistory.Clear();
		}

		private void CutBackTheList()
		{
			FileHistory.RemoveRange(currentFileHistoryIndex, FileHistory.Count - currentFileHistoryIndex);
		}
	}
}
