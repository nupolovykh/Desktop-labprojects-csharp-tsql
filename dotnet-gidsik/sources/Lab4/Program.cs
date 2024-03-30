using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab4
{
    class MyApplication : Application
    {
        public MyApplication() 
        {
            this.Startup += MyOnStartup;
        }

        protected void MyOnStartup(object sender, StartupEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }

    class Program
    {
        [STAThread]
        private static void Main()
        {
            var app = new MyApplication();
            app.Run();
        }
    }
}
