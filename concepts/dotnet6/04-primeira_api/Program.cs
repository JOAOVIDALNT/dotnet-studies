using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// Responsável por criar a aplicação web (hosting)


app.MapGet("/", () => "Hello World!");
// primeiro endpoint
// não é possível criar dois métodos get no mesmo path
app.MapPost("/", () => "João Vidal");
app.MapGet("/user", () => "João Vidal");
app.MapGet("/userFull", () => new {Name = "João Vidal", Age = 23});

app.MapGet("/AddHeader", (HttpResponse response) => 
{
    response.Headers.Add("Teste", "Joao Vidal");
    return "Olá";
});

// body parameter
app.MapPost("/saveproduct", (Product product) => {
    // return product.Code + " - " + product.Name;
    ProductRepository.Add(product);
} ); // -> informação passada através do body (corpo da req) no postman

// query parameter
//api.app.com/users?datestart={date}&dateend={date}
app.MapGet("getproduct", ( [FromQuery] string datestart, [FromQuery] string dateend) => {
    return datestart + " - " + dateend;
});
// url parameter
//api.app.com/user/{code}
app.MapGet("getproduct/{code}", ([FromRoute] string code) => {
    // return code;
    var product = ProductRepository.GetBy(code);
    return product;
});

// header parameter
app.MapGet("/getproductbyheader", (HttpRequest request) => {
    return request.Headers["product-code"].ToString; // dictionary, mapeado por chave e valor
}); // -> normalmente usado pra enviar um token (não muito utilizado)

app.MapPut("/editproduct", (Product product) => {
    var productrepo = ProductRepository.GetBy(product.Code);
    productrepo.Name = product.Name;
});

app.MapDelete("/deleteproduct/{code}", ([FromRoute] string code) => {
    var productrepo = ProductRepository.GetBy(code);
    ProductRepository.Remove(productrepo);
});

app.Run();
// manda rodar o app

// em Properties > launchSettings.json é possível visualizar e alterar as portas


public static class ProductRepository // estática pois uma classe não estática acaba quando a req termina enquanto a classe estática fica na memória do servidor e é disponibilizada pra qualquer req.
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