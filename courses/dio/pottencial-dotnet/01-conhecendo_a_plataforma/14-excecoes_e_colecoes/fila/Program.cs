Queue<int> fila = new Queue<int>();

fila.Enqueue(2);
fila.Enqueue(4);
fila.Enqueue(6);
fila.Enqueue(8);

foreach (int item in fila)
{
    Console.WriteLine(item);
}

// fila.Dequeue(); -> sempre remove o primeiro elemento 

Console.WriteLine($"Removing element: {fila.Dequeue()}"); // remove e retorna o elemento do começo da fila
fila.Enqueue(10);

foreach (int item in fila)
{
    Console.WriteLine(item);
}