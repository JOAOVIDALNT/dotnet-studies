

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/villalogs.txt", rollingInterval:RollingInterval.Day).CreateLogger();
// // Configuração do serilog para logar as infos em um arquivo
// builder.Host.UseSerilog(); // define que o serilog será o logger padrão
builder.services.AddDbContext<ApllicationDbContext>(option => {
    option.UseNpgsql();
}  
);
builder.Services.AddControllers(
    option => {
        // option.ReturnHttpNotAcceptable = true; // Aceita apenas Json, caso passemos accept xml no header ele retorna não permitido ao invés de retornar o Json
    }
).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); // Define que se pedir xml retorna xml
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
