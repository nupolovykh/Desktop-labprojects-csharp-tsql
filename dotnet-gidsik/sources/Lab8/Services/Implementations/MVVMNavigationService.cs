using Lab8.Services.Interfaces;
using Lab8.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Services.Implementations
{
    public class MVVMNavigationService : IMVVMNavigationService
    {
        private readonly IServiceProvider _provider;
        public MVVMNavigationService(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected List<ViewModelBase> History { get; } = new List<ViewModelBase>();
        protected int currentViewIndex = -1;

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                ViewModelChanged?.Invoke(this, value);
            }
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            var newViewModel = _provider.GetRequiredService<TViewModel>();

            int oldAmount = History.Count;
            int newAmount = ++currentViewIndex + 1;

            if (oldAmount >= newAmount)
            {
                History.RemoveRange(currentViewIndex, oldAmount - newAmount + 1);
            }

            CurrentViewModel = newViewModel;
            History.Add(newViewModel);
        }

        public bool CanGoBack => currentViewIndex > 0;
        public void GoBack()
        {
            currentViewIndex--;
            CurrentViewModel = History[currentViewIndex];
        }
        public bool CanGoNext => currentViewIndex < History.Count - 1;
        public void GoNext()
        {
            currentViewIndex++;
            CurrentViewModel = History[currentViewIndex];
        }

        public event EventHandler<ViewModelBase> ViewModelChanged;
    }
}
