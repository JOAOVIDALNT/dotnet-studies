using System;
using _01.Models;
using Newtonsoft.Json;

DateTime dateNow = DateTime.Now;

List<Product> productList = new List<Product>();

Product p1 = new Product(1, "Notebook", 1400.00M, dateNow);
Product p2 = new Product(2, "Smartphone", 800.00M, dateNow);

productList.Add(p1);
productList.Add(p2);



string serialized = JsonConvert.SerializeObject(productList, Formatting.Indented);
// string serialized = JsonConvert.SerializeObject(p1, Formatting.Indented);

File.WriteAllText("File/sells.json", serialized);

Console.WriteLine(serialized);

