using Microsoft.Extensions.DependencyInjection;

namespace Lab3
{
    public partial class Main : Form
    {

        private readonly IServiceProvider _serviceProvider;
        public Main(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void btn_prdt_Click(object sender, EventArgs e)
        {
            //LoginDialog _LoginDialog = _serviceProvider.GetService<LoginDialog>()!;
            ProductForm productForm = _serviceProvider.GetService<ProductForm>()!;
            productForm.ShowDialog();
        }

        private void btn_mtrl_Click(object sender, EventArgs e)
        {
            MaterialForm materialForm = _serviceProvider.GetService<MaterialForm>()!;
            materialForm.ShowDialog();
        }
    }
}
