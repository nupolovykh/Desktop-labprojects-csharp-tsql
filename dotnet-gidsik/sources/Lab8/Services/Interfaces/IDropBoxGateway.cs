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
    public interface IDropBoxGateway
    {
        string ReferToBrowser { get; }

		string Token { get; }

		string CurrentPath { get; }

		Task<List<FileModel>> UpdateTheSnapshot();

		Task<bool> oAuth2Token(string key);

		Task<List<FileModel>> GetFoldersIn(GetFoldersInType navType, string? path = "");

		bool CanGoPrev { get; }

		Task<List<FileModel>> GoToThePrev();

		bool CanGoNext { get; }

		Task<List<FileModel>> GoToTheNext();

	}
}
