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
    public class MainViewModel : ViewModelBase
    {
        private readonly IMVVMNavigationService _nav;

        public MainViewModel(IMVVMNavigationService nav)
        {
            _nav = nav;
            _nav.ViewModelChanged += OnViewModelChanged;
        }

        private void OnViewModelChanged(object? sender, ViewModelBase e)
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            OnPropertyChanged(nameof(Title));
        }

        public new string Title => _nav.CurrentViewModel.Title;
        public ViewModelBase CurrentViewModel => _nav.CurrentViewModel;

        private ICommand _goBackCommand = null!;
        public ICommand GoBackCommand => _goBackCommand ??= new DelegatedCommand(
            action: _ => _nav.GoBack(),
            canExecute: _ => _nav.CanGoBack
        );

        private ICommand _goNextCommand = null!;
        public ICommand GoNextCommand => _goNextCommand ??= new DelegatedCommand(
            action: _ => _nav.GoNext(),
            canExecute: _ => _nav.CanGoNext
        );
    }
}
