using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.ViewModels
{
    public class PeopleViewModelSimple
    {
        private List<PersonModelSimple> _people = null!;

        private PersonModelSimple _person = null!;

        private int _percentDone = 10;

        public PeopleViewModelSimple()
        {
            _people = new List<PersonModelSimple> 
            {
                new PersonModelSimple { Id = 1, Name = "Nikita", Description = "Coolest", Birthday = new DateTime(2005, 01, 18)},
                new PersonModelSimple { Id = 2, Name = "Vasya", Description = "Cooler then majority", Birthday = new DateTime(2003, 10, 5)},
                new PersonModelSimple { Id = 3, Name = "Alina", Description = "Coolest of subhumans", Birthday = new DateTime(2006, 06, 21)},
                new PersonModelSimple { Id = 4, Name = "Liza", Description = "Just as bitch", Birthday = new DateTime(2008, 09, 04)},
                new PersonModelSimple { Id = 5, Name = "Victor", Description = "Gay", Birthday = new DateTime(2014, 03, 13)},
            };
        }

        public PersonModelSimple ChosenPerson
        {
            get { return _person; }
            set { _person = value; }
        }

        public List<PersonModelSimple> People => _people;

        public int PercentDone
        {
            get { return _percentDone; }
            set { _percentDone = value; }
        }

        public void BeginProcess()
        {
            while (PercentDone < 100)
            {
                PercentDone++;
            }
        }

        public void ResetProcess()
        {
            PercentDone = 0;
        }
    }
}
