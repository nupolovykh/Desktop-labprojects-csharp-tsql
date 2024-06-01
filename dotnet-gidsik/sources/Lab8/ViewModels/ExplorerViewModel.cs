using Lab8.Commands;
using Lab8.Models;
using Lab8.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab8.ViewModels
{
    internal class ExplorerViewModel : ViewModelBase
    {
        private readonly IMVVMNavigationService _navigation;
		private readonly IDropBoxReferModule _refer;

		public ExplorerViewModel(IMVVMNavigationService navigation, IDropBoxReferModule refer)
        {
            Title = "Explorer";
			_navigation = navigation;
			_refer = refer;

			exhibitted_token = _refer.Token;
		}

		private string exhibitted_token;

		public string ExhibittedToken
		{
			get { return exhibitted_token; }
			set { exhibitted_token = value; }
		}

		private List<FolderModel> foldersList;

		public List<FolderModel> FoldersList
		{
			get => foldersList;
			set { 
				foldersList = value;
				OnPropertyChanged();
			}
		}

		private FolderModel selectedFolder;

		public FolderModel SelectedFolder
		{
			get => selectedFolder;
			set
			{
				selectedFolder = value;
				OnPropertyChanged();
			}
		}

		private ICommand post = null!;

		public ICommand Post => post ??= new DelegatedCommand(
			action: async (_) => {
				FoldersList = await _refer.GetFoldersTree();
			},
			canExecute: _ => true
		);
	}
}
