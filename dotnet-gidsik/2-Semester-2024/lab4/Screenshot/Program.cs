using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Lab4;
using Lab4.Database;
using Lab4.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

if (args.Length < 1)
{
	Console.Error.WriteLine("Usage: Screenshot <output-png-path>");
	return 1;
}

var outputPath = args[0];

// WPF's Window/FrameworkElement machinery requires an STA thread; top-level
// statements don't run on one by default, so spin up a dedicated STA thread.
var thread = new Thread(() =>
{
	// WPF expects an Application instance to exist even though we never call Run().
	_ = new Application();

	var services = new ServiceCollection();
	services.AddTransient<MainWindow>();
	services.AddScoped<IDbWorker, DbWorker>();
	services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=./app.db"));
	var provider = services.BuildServiceProvider();

	var window = provider.GetRequiredService<MainWindow>();

	// A Window's own render root isn't fully constructed until it's actually
	// shown, so RenderTargetBitmap.Render(window) on an unshown window produces
	// blank output - render its Content instead, which has no such dependency.
	var content = (FrameworkElement)window.Content;
	var size = new Size(window.Width, window.Height);
	content.Measure(size);
	content.Arrange(new Rect(size));
	content.UpdateLayout();

	var bitmap = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
	bitmap.Render(content);

	var encoder = new PngBitmapEncoder();
	encoder.Frames.Add(BitmapFrame.Create(bitmap));

	Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputPath))!);
	using (var stream = File.Create(outputPath))
	{
		encoder.Save(stream);
	}
});
thread.SetApartmentState(ApartmentState.STA);
thread.Start();
thread.Join();

Console.WriteLine($"Saved {outputPath}");
return 0;
