using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace validacoes_no_get_e_set.Models
{
    public class Person
    {
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        /* MODIFICADORES DE ACESSO: 
        não pode ser acessada fora da classe, somente através da propriedade, que valida antes de atribuir o valor para o campo _name 
        */
        private string _name; 
        private int _age;
        /* 
            PROPRIEDADE: possui get ou set ex: public string Name
            CAMPO: possuio apenas a declaração ex: private string _name
        */
        public string Name 
        {
            get => _name.ToUpper(); // Body expression = retorna da mesma maneira sem o corpo do método
            // get
            // {
            //     return _name.ToUpper();
            // }
            set 
            {
                if(value == "")
                {
                    throw new ArgumentException("The field name can't be empty");
                }
                _name = value;
            }
        }
        public string Surname { get; set; }
        public string CompleteName => $"{Name} {Surname}".ToUpper(); // body expression para o método get
        /* CompleteName só possui o método get então não pode ser atribuida */
        public int Age 
        {
            get => _age;
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age can't be negative");
                }
                _age = value;
            }
        }


        public void Present() 
        {
            Console.WriteLine($"Name: {CompleteName}, Age: {Age}");
        }

        
    }
}