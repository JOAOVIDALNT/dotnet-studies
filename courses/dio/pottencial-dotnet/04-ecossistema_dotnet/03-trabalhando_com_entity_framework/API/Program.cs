using API.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AgendaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
/* 
Adiciona um dbcontext do tipo AgendaContext passando algumas opções:
> options.UseSqlServer - indica o db a ser usado (poderia ser MySql por exemplo)
> builder.Configuration - busca a configuração do appsettings.json
> .GetConnectionString("") - busca dentro do appsettings pela conexão passada no parâmetro
*/





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
