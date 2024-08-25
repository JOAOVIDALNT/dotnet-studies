

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using villa_app_api;
using villa_app_api.Data;
using villa_app_api.Repository;
using villa_app_api.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/villalogs.txt", rollingInterval:RollingInterval.Day).CreateLogger();
// // Configuração do serilog para logar as infos em um arquivo
// builder.Host.UseSerilog(); // define que o serilog será o logger padrão
builder.Services.AddDbContext<ApplicationDbContext>(option => {

    option.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"));

    //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    //option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}  
);
builder.Services.AddScoped<IVillaRepository, VillaRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));

var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false

        };
    });

builder.Services.AddControllers(
    option => {
        // option.ReturnHttpNotAcceptable = true; // Aceita apenas Json, caso passemos accept xml no header ele retorna não permitido ao invés de retornar o Json
    }
).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); // Define que se pedir xml retorna xml
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization using Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
