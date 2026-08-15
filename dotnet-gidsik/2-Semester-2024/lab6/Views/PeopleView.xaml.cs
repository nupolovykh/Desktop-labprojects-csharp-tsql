using Lab6.ViewModels;
using Lab6.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab6.Views
{
    /// <summary>
    /// Логика взаимодействия для PeopleView.xaml
    /// </summary>
    public partial class PeopleView : Window
    {
        private readonly IServiceProvider _provider = null!;

        //private PeopleViewModelSimple _plainViewModel = null!;
        private PeopleViewModelMVVM _observableViewModel = null!;

        public PeopleView(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
        }

        private void show_In_New_Window(object sender, RoutedEventArgs e)
        {
            var view = _provider.GetService<PeopleView>()!;
            view.DataContext = this.DataContext;
            view.Show();
        }

        private void push_New_Item(object sender, RoutedEventArgs e)
        {
            //_plainViewModel.People.Add(new PersonModelSimple());
            _observableViewModel.People.Add(new PersonModelMVVM());
        }

        private void change_Selected_Item(object sender, RoutedEventArgs e)
        {
            //var current = _plainViewModel.ChosenPerson;
            var current = _observableViewModel.ChosenPerson;
            current.Id = 0;
            current.Name = "Nikita";
            current.Description = "Donkey";
            current.Birthday = DateTime.MinValue;
        }

        private void pop_Last_Item(object sender, RoutedEventArgs e)
        {
            //var count = _plainViewModel.People.Count;
            //if (count > 0) _plainViewModel.People.RemoveAt(count - 1);

            var count = _observableViewModel.People.Count;
            if (count > 0) _observableViewModel.People.RemoveAt(count - 1);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //_plainViewModel = (PeopleViewModelSimple)DataContext;
            _observableViewModel = (PeopleViewModelMVVM)DataContext;
        }

        private void BeginButton(object sender, RoutedEventArgs e)
        {
            //_plainViewModel.BeginProcess();
            _observableViewModel.BeginProcess();
        }

        private void ResetButton(object sender, RoutedEventArgs e)
        {
            //_plainViewModel.ResetProcess();
            _observableViewModel.ResetProcess();
        }
    }
}
