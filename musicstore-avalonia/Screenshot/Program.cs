using Avalonia;
using Avalonia.Headless;
using Avalonia.MusicStore;
using Avalonia.MusicStore.ViewModels;
using Avalonia.MusicStore.Views;
using Avalonia.ReactiveUI;

if (args.Length < 1)
{
	Console.Error.WriteLine("Usage: Screenshot <output-png-path>");
	return 1;
}

AppBuilder.Configure<App>()
	.UseReactiveUI()
	.UseSkia()
	.UseHeadless(new AvaloniaHeadlessPlatformOptions { UseHeadlessDrawing = false })
	.SetupWithoutStarting();

var window = new MainWindow
{
	DataContext = new MainWindowViewModel(),
};
window.Show();

var frame = window.CaptureRenderedFrame();
if (frame is null)
{
	Console.Error.WriteLine("CaptureRenderedFrame() returned null - nothing was rendered.");
	return 1;
}

var outputPath = args[0];
Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputPath))!);
frame.Save(outputPath);
Console.WriteLine($"Saved {outputPath}");
return 0;
