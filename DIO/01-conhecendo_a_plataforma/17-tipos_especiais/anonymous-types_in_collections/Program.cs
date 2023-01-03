using _02.Models;
using Newtonsoft.Json;

string fileContent = File.ReadAllText("File/sells.json");

List<Product> sellList = JsonConvert.DeserializeObject<List<Product>>(fileContent);

var anomList = sellList.Select(x => new { x.Name, x.Price}); // obtem através de um tipo anônimo apenas nome e preço 

foreach (var sell in anomList)
{
    Console.WriteLine($"Product: {sell.Name}, Price: {sell.Price}");
}