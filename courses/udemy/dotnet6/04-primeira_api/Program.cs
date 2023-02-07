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
    response.Headers.Add("Teste", "João Vidal");
    return "Olá";
});

// body parameter
app.MapPost("/saveproduct", (Product product) => {
    return product.Code + " - " + product.Name;
} ); // -> informação passada através do body (corpo da req) no postman

// query parameter
//api.app.com/users?datestart={date}&dateend={date}
app.MapGet("getproduct", ( [FromQuery] string datestart, [FromQuery] string dateend) => {
    return datestart + " - " + dateend;
});
// url parameter
//api.app.com/user/{code}
app.MapGet("getproduct/{code}", ([FromRoute] string code) => {
    return code;
});

// header parameter
app.MapGet("/getproductbyheader", (HttpRequest request) => {
    return request.Headers["product-code"].ToString; // dictionary, mapeado por chave e valor
}); // -> normalmente usado pra enviar um token (não muito utilizado)

app.Run();
// manda rodar o app

// em Properties > launchSettings.json é possível visualizar e alterar as portas

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}
