using System.Globalization;

var anomType = new{Nome = "João", Sobrenome = "Vidal", Idade = 22};

Console.WriteLine($"Nome: {anomType.Nome}"); // Propriedade readonly (possui apenas o método get)
Console.WriteLine($"Sobrenome: {anomType.Sobrenome}");
Console.WriteLine($"Idade: {anomType.Idade}");

// TIPO ANONIMO NÃO PODE SER RETORNADO EM MÉTODOS