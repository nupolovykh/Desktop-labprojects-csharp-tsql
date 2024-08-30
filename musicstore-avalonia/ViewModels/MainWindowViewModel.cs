using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows.Input;

namespace Avalonia.MusicStore.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public MainWindowViewModel()
		{
			ShowDialog = new Interaction<MusicStoreViewModel, AlbumViewModel?>();

			BuyMusicCommand = ReactiveCommand.CreateFromTask(async () =>
			{
				var store = new MusicStoreViewModel();
				var result = await ShowDialog.Handle(store);
                
				if (result is not null)
                {
					Albums.Add(result);
					await result.SaveToDiskAsync();
                }
            });
		}

		public ICommand BuyMusicCommand { get; }

		public Interaction<MusicStoreViewModel, AlbumViewModel?> ShowDialog { get; }

		public ObservableCollection<AlbumViewModel> Albums { get; } = new();

	}
}
