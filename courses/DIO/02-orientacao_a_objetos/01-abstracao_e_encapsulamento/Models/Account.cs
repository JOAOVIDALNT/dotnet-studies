using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_abstracao_e_encapsulamento.Models
{
    public class Account
    {

        public Account(int accountId, decimal initialBalance)
        {
            AccountId = accountId;
            _balance = initialBalance;
        }
        public int AccountId { get; set; }
        private decimal _balance; // ENCAPSULAMENTO: Apenas a própria classe pode alterar o saldo

        public void withdraw(decimal value)
        {
            if (_balance >= value) // ENCAPSULAMENTO: Não permite sacar um valor maior que o saldo
            {
                _balance -= value;
            }
            else
            {
                Console.WriteLine("You don't have enough balance");
            }
        }

        public void showBalance()
        {
            Console.WriteLine("Your balance is " + _balance);
        }
    }
}