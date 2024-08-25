using _01.Models;
using System;

// PODE SUBSTITUIR CLASSES DE MANEIRA SIMPLES

(int, string, string, decimal) t1 = (1, "João", "Vidal", 1.65M);
// ValueTuple<int, string, string, decimal> anotherExample = (1, "João", "Vidal", 1.65M);
// var anotherExample2 = Tuple.Create(1, "João", "Vidal", 1.65M);

/* A MANEIRA MAIS RECOMENDADA DE UTILIZAR A TUPLA É A PRIMEIRA, POIS ALÉM DA LEGIBILIDADE, COM ELA TAMBÉM É POSSIVEL
NOMEAR OS ITENS
EX: (int Id, string name, string surname, decimal height) t2 = (1, "João", "Vidal", 1.65M); 
*/

Console.WriteLine($" ID: {t1.Item1}");
Console.WriteLine($" NAME: {t1.Item2}");
Console.WriteLine($" SURNAME: {t1.Item3}");
Console.WriteLine($" HEIGHT: {t1.Item4}");

Console.WriteLine("--------------------------------");
// TUPLAS EM MÉTODOS

FileReader file = new FileReader();

var (success, lines, linesCount) = file.FileRead("File/fileToRead.txt");

if (success)
{
    Console.WriteLine($"Quantity of lines at the file: {linesCount}");
    foreach (string line in lines)
    {
        Console.WriteLine(line);
    }  
}
else
{
    Console.WriteLine("Can't read the file");
}

// DESCARTE DE INFORMAÇÃO

var (sucesso, linhas, _) = file.FileRead("File/fileToRead.txt"); // O UNDERLINE DESCARTA A INFORMAÇÃO







