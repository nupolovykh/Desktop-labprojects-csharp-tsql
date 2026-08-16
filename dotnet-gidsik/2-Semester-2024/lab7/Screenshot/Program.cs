using System;
using System.IO;
using System.Threading;
using System.Windows;
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

	// Rendering Content directly without ever showing the Window skips WPF's
	// real initialization pass: implicit Grid resource styles (the TextBox
	// Style below) don't get applied and content isn't clipped to its layout
	// bounds, so text/controls render oversized and unstyled. Show it for
	// real, off-screen, like the analogous WinForms DrawToBitmap fix.
	window.WindowStartupLocation = WindowStartupLocation.Manual;
	window.Left = -32000;
	window.Top = -32000;
	window.ShowInTaskbar = false;
	window.Show();
	window.UpdateLayout();

	var content = (FrameworkElement)window.Content;
	var size = new Size(window.ActualWidth, window.ActualHeight);
	content.Measure(size);
	content.Arrange(new Rect(size));
	content.UpdateLayout();

	// RenderTargetBitmap defaults to a transparent canvas - paint an opaque
	// white background first (VisualBrush lets us draw the already laid-out
	// content on top without reparenting it), or the PNG ends up with a fully
	// transparent background and the text is invisible on anything but a
	// white page.
	var visual = new DrawingVisual();
	using (var dc = visual.RenderOpen())
	{
		dc.DrawRectangle(Brushes.White, null, new Rect(size));
		dc.DrawRectangle(new VisualBrush(content), null, new Rect(size));
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

	window.Close();
});
thread.SetApartmentState(ApartmentState.STA);
thread.Start();
thread.Join();

Console.WriteLine($"Saved {outputPath}");
return 0;
