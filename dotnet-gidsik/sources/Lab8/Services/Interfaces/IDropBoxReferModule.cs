using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Lab8.Services.Interfaces
{
    public interface IDropBoxReferModule
    {
        public string ReferToBrowser { get; }

		public string Token { get; }

		public Task<bool> oAuth2Token(string key);

		public Task<List<FolderModel>> GetFoldersTree();
	}
}
