using _01_abstracao_e_encapsulamento.Models;

Person p1 = new Person(); // ABSTRAÇÃO: Cria um objeto da classe pessoa

p1.Name = "João";
p1.Age = 22;

p1.Present();


Account a1 = new Account(13, 1000);

// ENCAPSULAMENTO: Métodos de controle que acessam o saldo internamento
// é impossivel, por exemplo, alterar o saldo usando a1._balance = 1000;
// mas é possível alterar o saldo utilizando métodos seguros 
a1.showBalance(); 
a1.withdraw(500);
a1.showBalance();

