
Em appsettings.json -> appsettings.Development.json, adicionaremos as informações de connection string:
```json
{
  "ConnectionStrings": {
    "DataBaseType": "0",
    "Conn1": "Server=localhost\\sqlexpress;Initial Catalog=MyCookBook;Integrated Security=True;TrustServerCertificate=True",
    "Conn2": "Server=localhost\\sqlexpress;Initial Catalog=MyCookBook;Integrated Security=True;TrustServerCertificate=True"
}
```

No 'AddInfraestructure' do nosso DI Extension, adicionaremos o parâmetro de IConfiguration
```csharp
public static void AddInfraestructure(this IServiceCollection services, IConfiguration config)
{
    AddDbContext(services);
    AddRepositories(services);
}
```

E no nosso program.cs, passaremos o builder.Configuration para o DI Extension acessar:
```csharp
builder.Services.AddInfraestructure(builder.Configuration);
```

Por fim, adicionaremos as seguintes linhas ao método AddInfraestructure do nosso DI Extension:
```csharp
var dbType = config.GetConnectionString("DatabaseType");

var dbTypeEnum = (DatabaseType)Enum.Parse(typeof(DatabaseType), dbType);

if (dbTypeEnum == DatabaseType.Conn1)
    AddDbContext(services, config.GetConnectionString("Conn1"));
else
    AddDbContext(services, config.GetConnectionString("Conn2"));
```
Observe que também criamos um enum em Domain.Enums -> DatabaseType.cs para associar os tipos