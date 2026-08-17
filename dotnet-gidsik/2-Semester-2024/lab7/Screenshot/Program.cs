using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Lab7.Views;

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

	var window = new Login();

	// A Window's own render root isn't fully constructed until it's actually
	// shown, so RenderTargetBitmap.Render(window) on an unshown window produces
	// blank output - render its Content instead, which has no such dependency.
	var content = (FrameworkElement)window.Content;
	var size = new Size(window.Width, window.Height);

	// RenderTargetBitmap defaults to a transparent canvas - a VisualBrush
	// painted behind the content (to add an opaque white background without
	// reparenting it) computes its own Viewbox from the content's visual
	// bounds and stretches to fill, which silently distorts/enlarges layouts
	// that don't exactly fill their arranged rect. Detach content from the
	// Window and wrap it in a Border instead - a real opaque background with
	// no brush-stretching involved.
	window.Content = null;
	var wrapper = new Border { Background = Brushes.White, Child = content };
	wrapper.Measure(size);
	wrapper.Arrange(new Rect(size));
	wrapper.UpdateLayout();

	var bitmap = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
	bitmap.Render(wrapper);

	var encoder = new PngBitmapEncoder();
	encoder.Frames.Add(BitmapFrame.Create(bitmap));

	Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputPath))!);
	using (var stream = File.Create(outputPath))
	{
		encoder.Save(stream);
	}

	window.Close();
});
thread.SetApartmentState(ApartmentState.STA);
thread.Start();
thread.Join();

Console.WriteLine($"Saved {outputPath}");
return 0;
