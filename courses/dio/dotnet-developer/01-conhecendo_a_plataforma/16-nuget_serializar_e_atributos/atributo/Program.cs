using _02.Models;
using Newtonsoft.Json;

string fileContent = File.ReadAllText("File/sells.json");

List<Product> sellList = JsonConvert.DeserializeObject<List<Product>>(fileContent);

foreach (Product sell in sellList)
{
    Console.WriteLine($"Id: {sell.Id}, Product: {sell.Name}, Price: {sell.Price}, Sell Date: {sell.SellDate.ToString("dd/MM/yyyy HH:mm")}");
}