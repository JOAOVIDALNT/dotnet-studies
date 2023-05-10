using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stack_heap_e_gb_collector.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public string completeName => $"{Name} {Surname}";
        
    }
}