using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// Responsável por criar a aplicação web (hosting)

app.MapPost("/products", (Product product) => {
    ProductRepository.Add(product);
    return Results.Created($"/products/{product.Code}", product.Code);
    // retorna status created: recebe o parâmetro do caminho e o objeto, nesse caso retorna apenas o code
} );

app.MapGet("products/{code}", ([FromRoute] string code) => {
    var product = ProductRepository.GetBy(code);
    if(product != null)
        return Results.Ok(product); // deve retornar dentro de um Results pois está comprometido com o notfound
    return Results.NotFound();
});

app.MapPut("/products", (Product product) => {
    var productrepo = ProductRepository.GetBy(product.Code);
    productrepo.Name = product.Name;
    return Results.Ok();
});

app.MapDelete("/products/{code}", ([FromRoute] string code) => {
    var productrepo = ProductRepository.GetBy(code);
    ProductRepository.Remove(productrepo);
    return Results.Ok();
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