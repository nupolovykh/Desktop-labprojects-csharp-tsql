using Lab8.Commands;
using Lab8.Models;
using Lab8.Services.Interfaces;
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

		private List<FileModel> filesList;

		public List<FileModel> FilesList
		{
			get => filesList;
			set 
			{ 
				filesList = value;
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
				FilesList = await _refer.GetFoldersTreeIn(GetFoldersTreeInType.newFolder);
			},
			canExecute: _ => true
		);

		private ICommand passToSelectedFolder = null!;

		public ICommand PassToSelectedFolder => passToSelectedFolder ??= new DelegatedCommand(
			action: async (_) => {
				FilesList = await _refer.GetFoldersTreeIn(GetFoldersTreeInType.newFolder, SelectedFile.Path);
			},
			canExecute: _ => SelectedFile.Type is "folder"
		);

		private ICommand prev = null!;

		public ICommand Prev => prev ??= new DelegatedCommand(
			action: async (_) => {
				FilesList = await _refer.GoToThePrev();
			},
			canExecute: _ => _refer.CanGoPrev
		);

		private ICommand next = null!;

		public ICommand Next => next ??= new DelegatedCommand(
			action: async (_) => {
				FilesList = await _refer.GoToTheNext();
			},
			canExecute: _ => _refer.CanGoNext
		);
	}
}
