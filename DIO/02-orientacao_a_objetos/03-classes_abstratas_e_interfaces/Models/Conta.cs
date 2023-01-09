using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_classes_abstratas_e_interfaces.Models
{
    public abstract class Conta
    {
        protected decimal saldo; 
        // PROTECTED: PROTEGIDO CONTRA ALTERAÇÕES EXTERNAS COM EXCESSÃO DAS CLASSES FILHAS
        // ENQUANTO PRIVATE APENAS A PRÓPRIA CLASSE PODE ACESSAR

        public abstract void Creditar(decimal valor); 
        // MÉTODO ABSTRATO PARA SER IMPLEMENTADO EM ContaCorrente
        // CLASSES QUE IMPLEMENTAM A CLASSE CONTA DEVEM IMPLEMENTAR TAMBÉM SEUS MÉTODOS ABSTRATOS

        public void ExibirSaldo()
        {
            Console.WriteLine($"O seu saldo é de R${saldo}");   
        }
        
    }
}