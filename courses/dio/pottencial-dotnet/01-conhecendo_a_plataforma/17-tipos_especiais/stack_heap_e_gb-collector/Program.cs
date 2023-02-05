using System;
using stack_heap_e_gb_collector.Models;

Person p1 = new Person("João", "Vidal", 22);
// Person p2 = new Person("Giulia", "Vidal", 19);
Person p2 = p1;
p2.Name = "Amelie";
 
/*
EXPLICAÇÃO: QUANDO P2 RECEBE P1, ELE NÃO CRIA UM OBJETO INDEPENDENTE.
            ELE APENAS GUARDA OUTRA VARIÁVEL NA STACK QUE APONTA PARA O MESMO OBJETO NO HEAP
            (NÃO SE APLICA PARA TIPOS PRIMITIVOS)
 */ 

Console.WriteLine($"Nome da pessoa p1 {p1.completeName}");
Console.WriteLine($"Nome da pessoa p2 {p2.completeName}");

// OUTPUT: p1 Amelie Vidal
//         p2 Amelie Vidal
