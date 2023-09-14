using JwtStore.Models;
using JwtStore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<TokenService>();

var app = builder.Build();

app.MapGet("/", (TokenService service) => service.Create(new User(1, "João", "teste@fejota.com", "imagem", "1234", new[]
{
    "Student"
})));

app.Run();
