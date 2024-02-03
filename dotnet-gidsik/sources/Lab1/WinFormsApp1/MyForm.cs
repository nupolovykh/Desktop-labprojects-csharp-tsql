namespace WinFormsApp1;

public partial class MyForm : Form
{

    public string Password { get => myUserControl1.password; }
    public MyForm()
    {
        InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        this.Close();
    }

    private void btnShowDialogForm_Click(object sender, EventArgs e)
    {
        var dialogForm = new MyForm();
        dialogForm.ShowDialog();

        MessageBox.Show($"{dialogForm.DialogResult}");

        if (dialogForm.DialogResult == DialogResult.OK)
        {
            MessageBox.Show($"{dialogForm.Password}");
        }
    }

    private void MyComponent_Tick(object sender, EventArgs e)
    {
        lblMyComponentText.Text = $"{sender} - {DateTime.Now}";
    }
}