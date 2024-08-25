// FOR e WHILE são identicos ao java, do while também

int soma = 0, numero = 0;

do 
{
    Console.WriteLine("Digite um número (0 para parar)");
    numero = Convert.ToInt32(Console.ReadLine()); // readline le primariamente uma string, é preciso converter

    soma += numero;

 } while (numero != 0);

 Console.WriteLine($"Soma dos números digitados: {soma}");
