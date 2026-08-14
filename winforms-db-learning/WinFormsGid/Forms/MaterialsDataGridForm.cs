using WinFormsApp.Services.Interfaces;

namespace WinFormsApp.Forms;

internal partial class MaterialsDataGridForm : Form
{
	private readonly IDbWorker _db;

	public MaterialsDataGridForm(IDbWorker db)
	{
		InitializeComponent();
		_db = db;
	}

	private void MaterialsDataGridForm_Load(object sender, EventArgs e)
	{
		dgvMaterials.DataSource = _db.Materials;
	}
	private void btnSave_Click(object sender, EventArgs e)
	{
		_db.SaveChanges();
	}
}
