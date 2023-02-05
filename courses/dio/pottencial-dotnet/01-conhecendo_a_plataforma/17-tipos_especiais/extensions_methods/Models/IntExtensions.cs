using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace extensions_methods.Models
{
    public static class IntExtensions
    {
        public static bool EhPar(this int number) // this extende o comportamento do int, ou seja: toda variável int vai ter acesso à esse método e o parâmetro vira ele mesmo
        {
            return number % 2 == 0;
        }
    }
}