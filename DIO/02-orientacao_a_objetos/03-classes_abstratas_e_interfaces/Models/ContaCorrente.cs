using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_classes_abstratas_e_interfaces.Models
{
    public class ContaCorrente : Conta
    {
        public override void Creditar(decimal valor)
        {
            saldo += valor;
        }
    }
}