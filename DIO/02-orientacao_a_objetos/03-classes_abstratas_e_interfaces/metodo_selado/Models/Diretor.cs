using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_heranca_e_polimorfismo.Models
{
    public class Diretor : Teacher
    {
        public override void Present() // NÃO PODE SOBREESCREVER O MÉTODO POIS É SEALED (FINAL)
        {
            Console.WriteLine("Diretor");
        }
    }
}