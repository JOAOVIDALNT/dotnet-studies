using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_heranca_e_polimorfismo.Models
{
    public class Student : Person
    {
        // HERANÇA: Student herda as propriedas Name e Age de Person
        public double Grade { get; set; }


        public override void Present()  // POLIMORFISMO: override sobreescreve o método Present()
        {
            Console.WriteLine($"Olá, meu nome é {Name}, tenho {Age} anos e sou um aluno nota {Grade}");
        }
    }
}