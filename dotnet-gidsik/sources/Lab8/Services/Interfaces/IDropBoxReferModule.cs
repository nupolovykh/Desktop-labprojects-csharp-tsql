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
        string ReferToBrowser { get; }

		string Token { get; }

		Task<bool> oAuth2Token(string key);

		Task<List<FileModel>> GetFoldersTreeIn(GetFoldersTreeInType navType, string? path = "");

		bool CanGoPrev { get; }

		Task<List<FileModel>> GoToThePrev();

		bool CanGoNext { get; }

		Task<List<FileModel>> GoToTheNext();

	}
}
