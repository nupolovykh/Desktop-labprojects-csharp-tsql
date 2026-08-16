using System.Reflection.Metadata.Ecma335;

namespace Library
{
    public class Person
    {
        private string _name;
        private int _age {get; set;}

        public string name{
            get{return _name;}
        }

        public int age{
            get{return _age;}
        }

        public Person(string Name, int Age)
        {
            _name = Name;
            _age = Age;
        }
    }

    
}