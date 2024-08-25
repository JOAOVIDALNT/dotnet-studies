using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_de_projeto.Models
{
    public abstract class Smartphone
    {
        public string Numero { get; set; }
        public string Modelo { get; set; }
        public string Imei { get; set; }
        public int Memoria { get; set; }

        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            Imei = imei;
            Memoria = memoria;
        }

        public void Ligar()
        {
            Console.WriteLine("Ligando..");
        }

        public void RecebendoLigação()
        {
            Console.WriteLine("Recebendo ligação..");
        }

        public abstract void InstalarApp(string nomeApp);
    }
}