var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// Responsável por criar a aplicação web (hosting)


app.MapGet("/", () => "Hello World!");
// primeiro endpoint

app.Run();
// manda rodar o app

// em Properties > launchSettings.json é possível visualizar e alterar as portas
