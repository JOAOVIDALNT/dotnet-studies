
Dentro de Infraestructure, criaremos uma pasta 'Extensions' e dentro dessa pasta criaremos a classe 'ConfigurationExtension' para centralizar os acessos a configuration.

```csharp
using Microsoft.Extensions.Configuration;
using MyCookBook.Domain.Enums;

namespace MyCookBook.Infrastructure.Extensions
{
    public static class ConfigurationExtension
    {

        public static DatabaseType DatabaseType (this IConfiguration config)
        {
            var databaseType = config.GetConnectionString("DatabaseType");

            return (DatabaseType)Enum.Parse(typeof(DatabaseType), databaseType!);
        }

        public static string ConnectionString(this IConfiguration config)
        {
            var dbType = config.DatabaseType();

            if (dbType == Domain.Enums.DatabaseType.Conn1)
                return config.GetConnectionString("Conn1")!;
            else
                return config.GetConnectionString("Conn2")!;
        }
    }
}
```
A ideia aqui é garantir que, se alterarmos o nome de uma connection string nas configurações, não precisaremos alterar em vários trechos do código.


#### Exemplo em DIExtension
##### Antes
```csharp
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            var dbType = config.GetConnectionString("DatabaseType");

            var dbTypeEnum = (DatabaseType)Enum.Parse(typeof(DatabaseType), dbType);

            if (dbTypeEnum == DatabaseType.Conn1)
                AddDbContext(services, config.GetConnectionString("Conn1"));
            else
                AddDbContext(services, config.GetConnectionString("Conn2"));

            AddRepositories(services);
        }
```
##### Depois
```csharp
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            var dbType = config.DatabaseType();

            if (dbType == DatabaseType.Conn1)
                AddDbContext(services, config.ConnectionString());
            else
                AddDbContext(services, config.ConnectionString());

            AddRepositories(services);
        }
```

### MigrateDatabase
Além disso, migraremos a base de dados direto no Program.cs:

```csharp
MigrateDatabse();

app.Run();


void MigrateDatabse()
{
    var dbType = builder.Configuration.DatabaseType();
    var connString = builder.Configuration.ConnectionString();

    DatabaseMigration.Migrate(dbType, connString);
}
```
Com isso, executamos antes de rodar a aplicação a conferência sobre se já existe base e se não criamos ela.