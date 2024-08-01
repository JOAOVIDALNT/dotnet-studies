Para configurar as injeções do versionamento, utilizaremos a lib FluentMigrator.Runner

No primeiro passo da configuração, adicionaremos o método AddFluentMigrator no nosso DIExtension:

```csharp
private static void AddFluentMigrator(IServiceCollection services, IConfiguration config)
{
    var connString = config.ConnectionString();

    services.AddFluentMigratorCore().ConfigureRunner(options =>
    {
        options.AddSqlServer()
        .WithGlobalConnectionString(connString)
        .ScanIn(Assembly.Load("MyCookBook.Infrastructure")).For.All();
    });
}
```
Observe que:
- ScanIn recebe o Systen.Reflection.Assembly do projeto de infra, que é onde esta a pasta de Migrations. Com esse método indicamos de que projeto o Fluent deve mapear as migrações.

Também complementamos a condicional em AddInfrastructure:
```csharp
            if (dbType == DatabaseType.Conn1)
            {
                AddDbContext(services, config.ConnectionString());
                AddFluentMigrator(services, config);
            }
            else
            {
                AddDbContext(services, config.ConnectionString());
                AddFluentMigrator(services, config);
            }
```
A condicional só serviria caso estivéssemos utilizando 2 bases ou ambientes, pro nosso caso é irrelevante.

### Ajustando migrações
Após as configurações base, vamos definir em DatabaseMigration.cs o método de migração:

```csharp
private static void MigrationDatabase(IServiceProvider serviceProvider)
{
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

    runner.ListMigrations();

    runner.MigrateUp();
}
```

Agora, no primeiro método Migrate() de DatabaseMigration.cs, adicionamos a referência:
```csharp
public static void Migrate(DatabaseType databaseType, string connectionString, IServiceProvider serviceProvider)
{
    if (databaseType == DatabaseType.Conn1)
        EnsureDatabaseCreated_SqlServer(connectionString);

    MigrationDatabase(serviceProvider);
}
```
Observe que:
- Estamos passando o service provider que deve vir de um escopo de app em program.cs:
```csharp
app.Run();


void MigrateDatabse()
{
    var dbType = builder.Configuration.DatabaseType();
    var connString = builder.Configuration.ConnectionString();

    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

    DatabaseMigration.Migrate(dbType, connString, serviceScope.ServiceProvider);
}
```

### ServiceProvider
É o serviço da injeção de dependência, que adicionamos em services.AddFluentMigrator() representado pela interface IMigrationRunner.

### Conclusão
Essas configurações não devem ser necessárias novamente, visto que a partir de agora o Fluent administrara as migrações conforme adicionamos elas.