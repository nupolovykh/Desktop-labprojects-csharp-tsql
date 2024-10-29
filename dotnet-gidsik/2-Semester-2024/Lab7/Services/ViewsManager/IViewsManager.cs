using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab7.Services.ViewManager
{
    public interface IViewsManager
    {
        Window CurrentWindow { get; }

        void Open<IView>(object? dataContext = null) where IView : Window;
    }
}
