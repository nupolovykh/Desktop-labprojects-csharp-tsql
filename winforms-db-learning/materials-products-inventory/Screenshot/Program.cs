using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WinFormsApp;
using WinFormsApp.Data;
using WinFormsApp.Services.Implementations;
using WinFormsApp.Services.Interfaces;

internal static class Program
{
	[STAThread]
	static int Main(string[] args)
	{
		if (args.Length < 1)
		{
			Console.Error.WriteLine("Usage: Screenshot <output-png-path>");
			return 1;
		}

		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);

		var services = new ServiceCollection();
		services.AddTransient<MainForm>();
		services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data source=./app.db"));
		services.AddScoped<IDbWorker, DbWorker>();
		var provider = services.BuildServiceProvider();

		using var form = provider.GetRequiredService<MainForm>();
		form.CreateControl();

		using var bitmap = new Bitmap(form.Width, form.Height);
		form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.Width, form.Height));

		var outputPath = args[0];
		Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputPath))!);
		bitmap.Save(outputPath, ImageFormat.Png);
		Console.WriteLine($"Saved {outputPath}");
		return 0;
	}
}
