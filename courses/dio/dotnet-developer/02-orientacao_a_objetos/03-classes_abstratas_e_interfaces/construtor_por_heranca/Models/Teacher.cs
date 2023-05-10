using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_heranca_e_polimorfismo.Models
{
    public class Teacher : Person
    {
        public Teacher(string name) : base(name)
        {
            // TRANSFERE A FUNÇÃO DO CONSTRUTOR DE TEACHER PARA O CONSTRUTOR DE PERSON
        }


        public decimal Salary { get; set; }

        public override void Present()
        {
            Console.WriteLine($"Olá, meu nome é {Name}, tenho {Age} anos e meu salário como professor é de R${Salary}");
        }
    }
}