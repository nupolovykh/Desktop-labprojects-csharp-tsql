using Lab6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Lab6.ViewModels
{
    public class PeopleViewModelMVVM : INotifyPropertyChanged
    {
        private ObservableCollection<PersonModelMVVM> _people { get; set; } = null!;

        private PersonModelMVVM _person { get; set; } = null!;

        private int _percentDone = 0;

        public PeopleViewModelMVVM()
        {
            _people = new ObservableCollection<PersonModelMVVM>
            {
                new PersonModelMVVM { Id = 1, Name = "Nikita", Description = "Coolest", Birthday = new DateTime(2005, 01, 18)},
                new PersonModelMVVM { Id = 2, Name = "Vasya", Description = "Cooler then majority", Birthday = new DateTime(2003, 10, 5)},
                new PersonModelMVVM { Id = 3, Name = "Alina", Description = "Coolest of subhumans", Birthday = new DateTime(2006, 06, 21)},
                new PersonModelMVVM { Id = 4, Name = "Liza", Description = "Just as bitch", Birthday = new DateTime(2008, 09, 04)},
                new PersonModelMVVM { Id = 5, Name = "Victor", Description = "Gay", Birthday = new DateTime(2014, 03, 13)},
            };
        }

        public ObservableCollection<PersonModelMVVM> People
        {
            get { return _people; }
            set {
                _people = value;
                OnPropertyChanged();
            }
        }

        public PersonModelMVVM ChosenPerson
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public int PercentDone
        {
            get { return _percentDone; }
            set 
            { 
                _percentDone = value;
                OnPropertyChanged();
            }
        }

        private Task _process = null!;
        private CancellationTokenSource _token = new();

        public void BeginProcess()
        {
            if (_process is not null) return;

            _process = Task.Run(() =>
            {
                while (PercentDone < 100)
                {
                    _token.Token.ThrowIfCancellationRequested();
                    PercentDone++;
                    Task.Delay(100).Wait();
                }
            }, _token.Token);
        }

        public void ResetProcess()
        {
            if (_process is null)
            {
                PercentDone = 0;
                return;
            }

            _token.Cancel();

            try
            {
                _process.Wait(1000);
            }

            catch (Exception) { }

            finally
            {
                PercentDone = 0;
                _process.Dispose();
                _process = null!;
                _token = new CancellationTokenSource();
            }
        }

        /// <summary>
        /// ctrl + cancel => shift + ] == big brain move
        /// </summary>

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
