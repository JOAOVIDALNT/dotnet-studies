using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// Responsável por criar a aplicação web (hosting)

app.MapPost("/saveproduct", (Product product) => {
    ProductRepository.Add(product);
} );

app.MapGet("getproduct/{code}", ([FromRoute] string code) => {
    var product = ProductRepository.GetBy(code);
    return product;
});

app.MapPut("/editproduct", (Product product) => {
    var productrepo = ProductRepository.GetBy(product.Code);
    productrepo.Name = product.Name;
});

app.MapDelete("/deleteproduct/{code}", ([FromRoute] string code) => {
    var productrepo = ProductRepository.GetBy(code);
    ProductRepository.Remove(productrepo);
});

app.Run();

public static class ProductRepository 
{
    public static List<Product> Products { get; set;}

    public static void Add(Product product)
    {
        if (Products == null)
            Products = new List<Product>();
        Products.Add(product);
    }

    public static void Remove(Product product)
    {
        Products.Remove(product);
    }

    public static Product GetBy(string code)
    {
        // return Products.First(p => p.Code == code);
        return Products.FirstOrDefault(p => p.Code == code); // para tratar o erro caso o code não exista retorna null
    }

}

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}