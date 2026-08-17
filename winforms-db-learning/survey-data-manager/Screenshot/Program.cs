using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyWinFormsAppForDb;
using MyWinFormsAppForDb.Models;
using MyWinFormsAppForDb.Services.Implementations;
using MyWinFormsAppForDb.Services.Interfaces;

if (args.Length < 1)
{
	Console.Error.WriteLine("Usage: Screenshot <output-png-path> [entrance|records|analytics]");
	return 1;
}

// Which screen to capture - RecordsForm/Analytics both need a logged-in user
// (Personalization() reads the current role to pick which tables/buttons are
// visible), so log one in directly via IUserIdentity rather than driving
// Entrance's login form headlessly.
var screen = args.Length > 1 ? args[1] : "entrance";

Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);

var services = new ServiceCollection();
services.AddSingleton<Entrance>();
services.AddTransient<Main>();
services.AddTransient<RecordsForm>();
services.AddTransient<Analytics>();
services.AddDbContext<AppDbContext>();
services.AddScoped<IDbWorker, RealDbWorker>();
services.AddSingleton<IUserIdentity, UserIdentity>();
var provider = services.BuildServiceProvider();

Form form;
if (screen is "records" or "analytics")
{
	var identity = provider.GetRequiredService<IUserIdentity>();
	var worker = provider.GetRequiredService<IDbWorker>();
	var admin = worker.Users.First(u => u.Login == "admin");
	identity.Login(admin);

	form = screen == "records"
		? provider.GetRequiredService<RecordsForm>()
		: provider.GetRequiredService<Analytics>();
}
else
{
	form = provider.GetRequiredService<Entrance>();
}

using (form)
{
	// DrawToBitmap doesn't paint child controls correctly on a form that's
	// never actually been shown (a documented WinForms limitation) - show it
	// for real, just positioned off the visible desktop so nothing appears
	// on screen.
	form.StartPosition = FormStartPosition.Manual;
	form.Location = new Point(-32000, -32000);
	form.ShowInTaskbar = false;
	form.Show();
	Application.DoEvents();

	// KNOWN LIMITATION: RecordsForm/Analytics's Designer-declared ClientSize
	// is 1108x598, but in this CI environment the form actually renders
	// narrower than that (~1044px) - AutoScaleMode, MaximumSize/MinimumSize,
	// and forcing ClientSize directly were all tried and none of them
	// changed what DrawToBitmap actually paints, so the right-most controls
	// (Search, DESC, the second CRUD button column, Return to) end up
	// outside the captured frame.

	// RecordsForm/Analytics populate their grid/chart via an async void event
	// handler fired from setting SelectedIndex in the constructor - pump the
	// message loop a few times so that continuation actually completes
	// before capturing, instead of racing ahead to an empty grid/chart.
	for (var i = 0; i < 20; i++)
	{
		Application.DoEvents();
		Thread.Sleep(100);
	}

	// DrawToBitmap paints the control's *client area* into the bitmap's
	// top-left corner, not its full outer bounds - Width/Height (which
	// include the title bar and borders) would leave a blank margin of
	// uninitialized pixels along the right/bottom edge. ClientSize is what
	// actually gets painted, so allocate exactly that.
	using var bitmap = new Bitmap(form.ClientSize.Width, form.ClientSize.Height);
	form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, form.ClientSize));
	form.Close();

	var outputPath = args[0];
	Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputPath))!);
	bitmap.Save(outputPath, ImageFormat.Png);
	Console.WriteLine($"Saved {outputPath}");
}

return 0;
