using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public partial class MyComponent : Component
    {
        public event EventHandler? Tick;
        public MyComponent()
        {
            InitializeComponent();
            Init();
        }

        public MyComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            timer.Interval = 1000; //mlseconds
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Tick?.Invoke(this, EventArgs.Empty);
            Debug.WriteLine($"{DateTime.UtcNow}");
        }
    }
}
