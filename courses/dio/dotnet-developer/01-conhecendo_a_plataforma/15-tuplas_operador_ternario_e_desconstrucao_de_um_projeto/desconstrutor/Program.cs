using desconstrutor.Models;

Person p1 = new Person("João", "Vidal");

(string name, string surname) = p1;

Console.WriteLine($"{name} {surname}");

// DESCONSTRUTOR NÃO DESTROI, MAS SIM APLICA VALORES DE UM CONSTRUTOR Á VARIAVEIS
