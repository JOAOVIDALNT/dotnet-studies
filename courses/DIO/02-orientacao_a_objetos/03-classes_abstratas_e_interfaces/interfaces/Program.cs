using interfaces.Models;
using interfaces.Interfaces;

iCalculator calc = new Calculator(); // INTERFACE NÃO É INSTANCIAVEL, FUNCIONA POIS A CLASSE IMPLEMENTA A INTERFACE

Console.WriteLine(calc.Somar(4,6));