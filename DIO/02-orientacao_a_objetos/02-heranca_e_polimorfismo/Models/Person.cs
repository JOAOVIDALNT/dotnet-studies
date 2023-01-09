using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_heranca_e_polimorfismo.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Present()
        {
            Console.WriteLine($"Olá, meu nome é {Name} e tenho {Age} anos!");
        }
    }
}