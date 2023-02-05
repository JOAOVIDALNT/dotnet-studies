/* A sintaxe do c# é bem parecida com a do Java, porém alguns métodos são melhores adaptados 
como por exemplo: 
- .toString("0.00") no lugar do %.2f para formatar double 
- .toString("dd/MM/yyyy" ..) no DateTime no lugar de dateFormat
- a utilização do decimal para valores monetários
- a concatenação com $"exemplo {valor}"
*/

double price1 = 1.80;
Console.WriteLine("price 1: " + price1.ToString("0.00"));

decimal price2 = 1.80M;
Console.WriteLine($"price 2: {price2}");

DateTime timeNow = DateTime.Now;
Console.WriteLine($"time now: {timeNow}");
Console.WriteLine($"time 5 days: {timeNow.AddDays(5)}");
Console.WriteLine($"time now (short version): {timeNow.ToString("dd/MM/yyyy HH:mm")}");


