using Avalonia.MusicStore.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;

namespace Avalonia.MusicStore.Views
{
	public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
	{
		public MainWindow()
		{
			InitializeComponent();
			this.WhenActivated(action =>
				action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialog)));
		}

		private async Task DoShowDialog(InteractionContext<MusicStoreViewModel, AlbumViewModel?> interaction)
		{
			var dialog = new MusicStoreWindow();
			dialog.DataContext = interaction.Input;

			var result = await dialog.ShowDialog<AlbumViewModel?>(this);
			interaction.SetOutput(result);
		}
	}
}