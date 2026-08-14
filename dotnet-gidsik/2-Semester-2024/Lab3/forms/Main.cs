using Lab3.forms;
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

        private void btn_somethg1_Click(object sender, EventArgs e)
        {
            CustomProductForm customProductForm = _serviceProvider.GetService<CustomProductForm>()!;
            customProductForm.ShowDialog();
        }

        private void btn_somethng2_Click(object sender, EventArgs e)
        {
            CustomMaterialForm customMaterialForm = _serviceProvider.GetService<CustomMaterialForm>()!;
            customMaterialForm.ShowDialog();
        }
    }
}
