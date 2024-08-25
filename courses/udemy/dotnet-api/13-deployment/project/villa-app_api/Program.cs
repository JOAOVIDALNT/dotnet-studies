

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using villa_app_api;
using villa_app_api.Data;
using villa_app_api.Models.Entities;
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

builder.Services.AddResponseCaching(); // HABILITA O USO DE CACHE

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

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true; // ASSUME A VERSÃO DEFAULT, SEM ISSO É IMPOSSÍVEL REQUISITAR SEM DEFINIR
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true; // RETORNA A VERSÃO NO HEADER DA REQUISIÇÃO
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; // DEFINIÇÃO EM CASO DE PRECISAR ESPECIFICAR UMA VERSÃO
    options.SubstituteApiVersionInUrl = true; // SUBSTITUI A OPÇÃO DE REQUISITAR PASSANDO A VERSÃO /api/v{version}/villa-api -> /api/v1/villa-api
});

builder.Services.AddControllers(
    option => {
        option.CacheProfiles.Add("Default30",
            new CacheProfile()
            {
                Duration = 30
            });
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
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "Villa API",
        Description = "API to manage Villa",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "João Vidal",
            Url = new Uri("https://linktr.ee/fejota_dev")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/terms")
        }
    });

    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2.0",
        Title = "Villa API",
        Description = "API to manage Villa",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "João Vidal",
            Url = new Uri("https://linktr.ee/fejota_dev")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/terms")
        }
    });
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{ // -> REMOVIDO PARA A PUBLICAÇÃO
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "villa-api_v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "villa-api_v2");
        options.RoutePrefix = String.Empty;
    });
//}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
