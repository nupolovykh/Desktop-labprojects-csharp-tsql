using System;
using System.IO;
using System.Threading;
using Avalonia;
using Avalonia.Headless;
using Avalonia.MusicStore;
using Avalonia.MusicStore.ViewModels;
using Avalonia.MusicStore.Views;
using Avalonia.ReactiveUI;
using Avalonia.Threading;

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

// The empty MainWindow has no search box - it only appears inside the
// MusicStoreWindow dialog (shown via BuyMusicCommand in the real app), so
// screenshot that instead, with a real search performed.
var viewModel = new MusicStoreViewModel();
var window = new MusicStoreWindow
{
	DataContext = viewModel,
};
window.Show();

// SearchText changes are throttled 400ms then hit the real iTunes Search
// API - pump the dispatcher so that async chain actually runs (nothing
// drives it without a running Application.Run() loop).
viewModel.SearchText = "Queen";

var deadline = DateTime.UtcNow.AddSeconds(8);
while (DateTime.UtcNow < deadline && viewModel.SearchResults.Count == 0)
{
	Dispatcher.UIThread.RunJobs();
	Thread.Sleep(100);
}
// A few more pumps so the results list actually lays out before capture.
for (var i = 0; i < 10; i++)
{
	Dispatcher.UIThread.RunJobs();
	Thread.Sleep(100);
}

if (viewModel.SearchResults.Count == 0)
{
	Console.Error.WriteLine("Warning: search returned no results (network unavailable?) - capturing the empty search box anyway.");
}

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
