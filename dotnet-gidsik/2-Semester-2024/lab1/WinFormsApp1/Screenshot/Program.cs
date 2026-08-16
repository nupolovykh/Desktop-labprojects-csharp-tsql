using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using WinFormsApp1;

if (args.Length < 1)
{
	Console.Error.WriteLine("Usage: Screenshot <output-png-path>");
	return 1;
}

Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);

using var form = new MainForm();

// DrawToBitmap doesn't paint child controls correctly on a form that's never
// actually been shown (a documented WinForms limitation) - show it for real,
// just positioned off the visible desktop so nothing appears on screen.
form.StartPosition = FormStartPosition.Manual;
form.Location = new Point(-32000, -32000);
form.ShowInTaskbar = false;
form.Show();
Application.DoEvents();

using var bitmap = new Bitmap(form.Width, form.Height);
form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.Width, form.Height));
form.Close();

var outputPath = args[0];
Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputPath))!);
bitmap.Save(outputPath, ImageFormat.Png);
Console.WriteLine($"Saved {outputPath}");
return 0;
