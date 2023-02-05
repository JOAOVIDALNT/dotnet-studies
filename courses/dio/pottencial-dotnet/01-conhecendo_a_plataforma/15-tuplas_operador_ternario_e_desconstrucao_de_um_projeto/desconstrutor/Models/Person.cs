using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desconstrutor.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person (string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public void Deconstruct(out string name, out string surname)
        {
            name = Name;
            surname = Surname;
        }


    }
}