using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_abstracao_e_encapsulamento.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Present()
        {
            Console.WriteLine($"Hi, my name is {Name} and i'm {Age} years old");
        }
    }
    // a classe é apenas uma representação, para criar um objeto é preciso instanciar
}