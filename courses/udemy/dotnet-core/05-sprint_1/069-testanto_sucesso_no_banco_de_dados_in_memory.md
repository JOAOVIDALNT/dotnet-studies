Se executarmos os testes de integração, antes de definir algumas configurações resultará em alguns erros de configuração, para corrigir isso faremos os seguintes ajustes:

#### Definindo ambiente de teste

Em `appsettings.Test.json` adicionaremos o atributo `InMemoryTest`:
```json
{
  "InMemoryTest": true,
  "Settings": {
    "Password": {
      "SecretKey": "abcd1234"
    }
  }
}
```
ele não precisa ser adicionados aos outros ambientes pois a não identificação dele retornará false.

#### Adicionando extensão de `configuration`

Depois, podemos adicionar em `Infraestructure/Extension/ConfigurationExtension.cs`
o método `booleando` que verifica o atributo `InMemoryTest`:
```csharp
public static bool IsUnitTestEnvironment(this IConfiguration config)
{
    return config.GetValue<bool>("InMemoryTest");
}
```
Observe que:
- Para ter acesso ao atributo GetValue<> precisamos instalar o pacote adicionar de `Microsoft.Extensions.Configuration` -> `Microsoft.Extensions.Configuration.Binder`.

#### Ajustando o `AddInfraestructure`
Antes de verificar o tipo da base de acordo com a `connectionString` que no caso de teste não existe, verificaremos se o ambiente é de testes:
```csharp
public static class DependencyInjectionExtension
{
    public static void AddInfraestructure(this IServiceCollection services, IConfiguration config)
    {
        AddRepositories(services);

        if (config.IsUnitTestEnvironment())
            return;

        var dbType = config.DatabaseType();

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
    }
```
Observe que:
- Jogamos o `AddRepositories` lá em cima, pois ele independe do restante.
- Validamos o ambiente e caso seja teste, não continuamos com a execução.

#### Ajustando `MigrateDatabase`
Faremos o mesmo para o método `MigrateDatabase` de `Program.cs`:
```csharp
void MigrateDatabse()
{
    if (builder.Configuration.IsUnitTestEnvironment())
        return;

    var dbType = builder.Configuration.DatabaseType();
    var connString = builder.Configuration.ConnectionString();

    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

    DatabaseMigration.Migrate(dbType, connString, serviceScope.ServiceProvider);
}
```