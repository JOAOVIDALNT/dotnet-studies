using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using interfaces.Interfaces;

namespace interfaces.Models
{
    public class Calculator : iCalculator // CALCULADORA IMPLEMENTA ICALCULADORA
    {
        // public int Dividir(int num1, int num2)
        // {
        //     return num1 / num2;
        // } -> NÃO PRECISA MAIS IMPLEMENTAR POIS A INTERFACE JÁ TEM CORPO

        public int Multiplicar(int num1, int num2)
        {
            return num1 * num2;
        }

        public int Somar(int num1, int num2)
        {
            return num1 + num2;
        }

        public int Subtrair(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}