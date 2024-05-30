using Lab8.Commands;
using Lab8.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab8.ViewModels
{
    internal class ExplorerViewModel : ViewModelBase
    {
        private readonly IMVVMNavigationService _nav;

        public ExplorerViewModel(IMVVMNavigationService nav)
        {
            Title = "Explorer";
            _nav = nav;
        }
    }
}
