using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Lab6.Views;
using Lab6.ViewModels;

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

	var viewModel = new PeopleViewModelMVVM();
	// The detail pane's TextBoxes are bound to ChosenPerson and center-aligned
	// (auto width) - with nothing selected they're empty and collapse to a
	// sliver. Select the first person so the pane has something to show.
	viewModel.ChosenPerson = viewModel.People.First();

	var window = new PeopleView(provider: null!)
	{
		DataContext = viewModel,
	};

	// A Window's own render root isn't fully constructed until it's actually
	// shown, so RenderTargetBitmap.Render(window) on an unshown window produces
	// blank output - render its Content instead, which has no such dependency.
	var content = (FrameworkElement)window.Content;
	var size = new Size(window.Width, window.Height);
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
});
thread.SetApartmentState(ApartmentState.STA);
thread.Start();
thread.Join();

Console.WriteLine($"Saved {outputPath}");
return 0;
