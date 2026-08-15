using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab7.Services.ViewManager
{
    internal class ViewsManager : IViewsManager
    {
        private Window _currentWindow;
        private readonly IServiceProvider _provider;

        public ViewsManager(IServiceProvider provider) 
        {
            _provider = provider;
        }

        public Window CurrentWindow => _currentWindow;

        public void Open<IView>(object? dataContext = null) where IView : Window
        {
            var view = _provider.GetRequiredService<IView>();
            _currentWindow?.Close();
            _currentWindow = view;

            if(dataContext is not null)
            {
                _currentWindow.DataContext = dataContext;
            }

            _currentWindow.Show();
        }
    }
}
