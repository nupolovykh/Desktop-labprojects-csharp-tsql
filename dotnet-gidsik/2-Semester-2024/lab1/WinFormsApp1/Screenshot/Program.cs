using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
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

// btnAdd_Click just adds an empty PersonRecordUserControl (its fields all
// read "null" until the user opens the per-record Edit dialog) - the real
// lab demo is that control populated with data, not an empty one, so drive
// btnAdd's private click handler via reflection to add a few, then fill
// their (also private) textboxes directly rather than driving the modal
// Edit dialog headlessly.
var clickAdd = typeof(MainForm).GetMethod("btnAdd_Click", BindingFlags.NonPublic | BindingFlags.Instance)!;
var sampleRecords = new[]
{
	new { Id = "1", Name = "John", LastName = "Smith", Surname = "Doe", Age = 25 },
	new { Id = "2", Name = "Alice", LastName = "Johnson", Surname = "Marie", Age = 31 },
};

var dataStorage = (FlowLayoutPanel)typeof(MainForm)
	.GetField("dataStorage", BindingFlags.NonPublic | BindingFlags.Instance)!
	.GetValue(form)!;

foreach (var record in sampleRecords)
{
	clickAdd.Invoke(form, new object?[] { null, EventArgs.Empty });
	var control = (PersonRecordUserControl)dataStorage.Controls[^1];

	void SetTextBox(string fieldName, string text) =>
		((TextBox)typeof(PersonRecordUserControl)
			.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)!
			.GetValue(control)!).Text = text;

	SetTextBox("txtBoxId", record.Id);
	SetTextBox("txtBoxName", record.Name);
	SetTextBox("txtBoxLN", record.LastName);
	SetTextBox("txtBoxSN", record.Surname);
	SetTextBox("txtBoxAge", record.Age.ToString());
	control.Age = record.Age;
}

typeof(MainForm).GetMethod("Recalculate", BindingFlags.NonPublic | BindingFlags.Instance)!.Invoke(form, null);
Application.DoEvents();

using var bitmap = new Bitmap(form.Width, form.Height);
form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.Width, form.Height));
form.Close();

var outputPath = args[0];
Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputPath))!);
bitmap.Save(outputPath, ImageFormat.Png);
Console.WriteLine($"Saved {outputPath}");
return 0;
