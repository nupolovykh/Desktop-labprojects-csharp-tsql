using Lab8.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Services
{
    public class MVVMNavigationService : IMVVMNavigationService
    {
        private readonly IServiceProvider _provider;
        public MVVMNavigationService(IServiceProvider provider) 
        {
            _provider = provider;
        }

        protected List<ViewModelBase> History { get; } = new List<ViewModelBase>();
        protected int _currentViewIndex = -1;

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                ViewModelChanged?.Invoke(this, value);
            }
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            var newViewModel = _provider.GetRequiredService<TViewModel>();

            int oldAmount = History.Count;
            int newAmount = ++_currentViewIndex + 1;

            if(oldAmount >= newAmount)
            {
                History.RemoveRange(_currentViewIndex, oldAmount - newAmount + 1);
            }

            CurrentViewModel = newViewModel;
            History.Add(newViewModel);
        }

        public bool CanGoBack => _currentViewIndex > 0;
        public void GoBack()
        {
            _currentViewIndex--;
            CurrentViewModel = History[_currentViewIndex];
        }
        public bool CanGoNext => _currentViewIndex < History.Count - 1;
        public void GoNext()
        {
            _currentViewIndex++;
            CurrentViewModel = History[_currentViewIndex];
        }

        public event EventHandler<ViewModelBase> ViewModelChanged;
    }
}
