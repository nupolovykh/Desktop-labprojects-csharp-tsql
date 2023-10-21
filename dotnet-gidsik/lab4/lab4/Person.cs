using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsAdmin { get; set; }
    }
}

