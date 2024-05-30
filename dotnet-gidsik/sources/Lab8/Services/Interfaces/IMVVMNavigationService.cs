using Lab8.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Services.Interfaces
{
    public interface IMVVMNavigationService
    {
        public ViewModelBase CurrentViewModel { get; set; }
        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
        public bool CanGoBack { get; }
        public void GoBack();
        public bool CanGoNext { get; }
        public void GoNext();

        public event EventHandler<ViewModelBase> ViewModelChanged;

    }
}
