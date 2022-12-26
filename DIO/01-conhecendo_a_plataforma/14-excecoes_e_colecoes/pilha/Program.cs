/* A STACK(PILHA) NO C# SEGUE O PRINCIPIO LIFO (LAST IN FIRST OUT) 
   DIFERENTE DA FILA QUE POR PADRÃO REMOVE O PRIMEIRO ELEMENTO
*/

Stack<int> pilha = new Stack<int>();

pilha.Push(2); // adiciona um item a pilha
pilha.Push(4);
pilha.Push(6);
pilha.Push(8);

foreach (int item in pilha)
{
    Console.WriteLine(item);
}

Console.WriteLine($"Removing first element {pilha.Pop()}");

pilha.Push(10);

foreach (int item in pilha)
{
    Console.WriteLine(item);
}


