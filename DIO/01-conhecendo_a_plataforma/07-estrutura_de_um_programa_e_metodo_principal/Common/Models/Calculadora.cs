using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05_operadores_aritmeticos.Common.Models
{
    public class Calculadora
    {
        public void Somar(int x, int y) 
        {
            Console.WriteLine($"{x} + {y} = {x+y}");
        }

        public void Subtrair(int x, int y) 
        {
            Console.WriteLine($"{x} - {y} = {x-y}");
        }

        public void Multiplicar(int x, int y) 
        {
            Console.WriteLine($"{x} x {y} = {x*y}");
        }

        public void Dividir(int x, int y) 
        {
            Console.WriteLine($"{x} / {y} = {x/y}");
        }

        public void Potencia(int x, int y) 
        {
            double pot = Math.Pow(x,y);
            Console.WriteLine($"{x} ^ {y} = {pot}");
        }

        public void Seno(double angulo) 
        {
            double radiano = angulo * Math.PI / 180; // a operação Math precisa receber o valor radiano
            double seno = Math.Sin(radiano);
            Console.WriteLine($"Seno de {angulo}° = {Math.Round(seno, 4)}"); // Math.Round formata para 4 digitos
        }

        public void Coseno(double angulo) 
        {
            double radiano = angulo * Math.PI / 180;
            double coseno = Math.Cos(radiano);
            Console.WriteLine($"Coseno de {angulo}° = {Math.Round(coseno, 4)}");
        }

        public void Tangente(double angulo) 
        {
            double radiano = angulo * Math.PI / 180;
            double tangente = Math.Tan(radiano);
            Console.WriteLine($"Tangente de {angulo}° = {Math.Round(tangente, 4)}"); 
        }

        public void RaizQuadrada(double x)
        {
            double raiz = Math.Sqrt(x); // square root = raiz quadrada
            Console.WriteLine($"Raiz quadrada de {x} = {raiz}");
        }


    }
}