using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_de_projeto.Models
{
    public class iPhone : Smartphone
    {
        public iPhone(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
        {
        }

        public override void InstalarApp(string nomeApp)
        {
            Console.WriteLine($"Aplicativo {nomeApp} instalado via App Store");
        }
    }
}