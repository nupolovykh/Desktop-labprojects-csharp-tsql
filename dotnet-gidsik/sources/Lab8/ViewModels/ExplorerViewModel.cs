using Lab8.Commands;
using Lab8.Models;
using Lab8.Services.Interfaces;
using System.Windows.Input;

namespace Lab8.ViewModels
{
    internal class ExplorerViewModel : ViewModelBase
    {
        private readonly IMVVMNavigationService _navigation;
		private readonly IDropBoxGateway _gateway;

		public ExplorerViewModel(IMVVMNavigationService navigation, IDropBoxGateway gateway)
        {
            Title = "Explorer";
			_navigation = navigation;
			_gateway = gateway;

			AnyData = string.Concat("Token: ", _gateway.Token);
		}

		private string anyData;

		public string AnyData
		{
			get { return anyData; }
			set { 
				anyData = value;
				OnPropertyChanged();
			}
		}

		private List<FileModel> filesList;

		public List<FileModel> FilesList
		{
			get => filesList;
			set 
			{ 
				filesList = value;

				if (_gateway.CurrentPath == string.Empty) AnyData = "Token: " + _gateway.Token;
				else AnyData = "CurrentPath: " + _gateway.CurrentPath;

				OnPropertyChanged();
			}
		}

		private FileModel selectedFile;

		public FileModel SelectedFile
		{
			get => selectedFile;
			set
			{
				selectedFile = value;
				OnPropertyChanged();
			}
		}

		private ICommand getRoot = null!;

		public ICommand GetRoot => getRoot ??= new DelegatedCommand(
			action: async (_) =>
			{
				FilesList = await _gateway.GetFoldersIn(GetFoldersInType.newFolder);
			},
			canExecute: _ => true
		);

		private ICommand update = null!;

		public ICommand Update => update ??= new DelegatedCommand(
			action: async (_) =>
			{
				FilesList = await _gateway.UpdateTheSnapshot();
			},
			canExecute: _ => _gateway.CurrentPath is not null
		);

		private ICommand passToSelectedFolder = null!;

		public ICommand PassToSelectedFolder => passToSelectedFolder ??= new DelegatedCommand(
			action: async (_) => {
				FilesList = await _gateway.GetFoldersIn(GetFoldersInType.newFolder, SelectedFile.Path);
			},
			canExecute: _ => SelectedFile.Type is "folder"
		);

		private ICommand prev = null!;

		public ICommand Prev => prev ??= new DelegatedCommand(
			action: async (_) => {
				FilesList = await _gateway.GoToThePrev();
			},
			canExecute: _ => _gateway.CanGoPrev
		);

		private ICommand next = null!;

		public ICommand Next => next ??= new DelegatedCommand(
			action: async (_) => {
				FilesList = await _gateway.GoToTheNext();
			},
			canExecute: _ => _gateway.CanGoNext
		);
	}
}
