using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Lab8.Views;

if (args.Length < 1)
{
	Console.Error.WriteLine("Usage: Screenshot <output-png-path>");
	return 1;
}

var outputPath = args[0];

// Matches the XAML's d:DesignWidth/d:DesignHeight - LoginView is a UserControl,
// not a Window, so it has no intrinsic size of its own to measure against.
var size = new Size(800, 450);

// WPF's Window/FrameworkElement machinery requires an STA thread; top-level
// statements don't run on one by default, so spin up a dedicated STA thread.
var thread = new Thread(() =>
{
	// WPF expects an Application instance to exist even though we never call Run().
	_ = new Application();

	var view = new LoginView();
	view.Measure(size);
	view.Arrange(new Rect(size));
	view.UpdateLayout();

	// RenderTargetBitmap defaults to a transparent canvas - paint an opaque
	// white background first (VisualBrush lets us draw the already laid-out
	// view on top without reparenting it), or the PNG ends up with a fully
	// transparent background and the text is invisible on anything but a
	// white page.
	var visual = new DrawingVisual();
	using (var dc = visual.RenderOpen())
	{
		dc.DrawRectangle(Brushes.White, null, new Rect(size));
		dc.DrawRectangle(new VisualBrush(view), null, new Rect(size));
	}

	var bitmap = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
	bitmap.Render(visual);

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
