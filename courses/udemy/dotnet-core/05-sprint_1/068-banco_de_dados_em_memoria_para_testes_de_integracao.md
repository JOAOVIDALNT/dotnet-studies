
Para não popular a base com dados de testes, utilizaremos bancos de dados em memória para os testes de integração.

### Considerações iniciais
#### Ciclo de vida
Para os testes, o ciclo de vida da base de dados em memória vai ser único para cada classe de teste, ou seja, o ciclo de vida de uma base em memória não será maior do que o período de execução de uma classe de testes e para cada classe uma base será criada e excluída. 

#### Pacote
Utilizaremos o pacote Microsoft.EntityFrameworkCore.InMemory.

### Configuração
Precisamos garantir que as nossas configurações do `dbContext`se apliquem para uma base de dados em memória. Para isso, não utilizamos `connectionString` visto que se trata de um banco em memória, mas configuramos isso explicitamente no projeto `WebApi.Test` através da nova classe na raiz do projeto `CustomWebApplicationFactory`:

#### Extensão
Nossa nova classe `CustomWebApplicationFactory` deve estender de `WebApplicationFactory<>`
para configurar esse "servidor":
```csharp
public class CustomWebApplicationFactory : WebApplicationFactory<Program>
```
Com isso, podemos simplificar a extensão do nosso `RegisterUserTest`:
```csharp
public class RegisterUserTest : IClassFixture<CustomWebApplicationFactory>
```
Também é importante ajustar o contrutor:
```csharp
public RegisterUserTest(CustomWebApplicationFactory factory) => _httpClient = factory.CreateClient();
```


#### Setup
Agora, configuraremos o servidor sobrescrevendo o método `ConfigureWebHost` de `CustomWebApplicationFactory:WebApplicationFactory`:
```csharp
protected override void ConfigureWebHost(IWebHostBuilder builder)
{
    builder.UseEnvironment("Test")
        .ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<MyCookBookDbContext>));

            if (descriptor is not null)
                services.Remove(descriptor);

            var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

            services.AddDbContext<MyCookBookDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
                options.UseInternalServiceProvider(provider);
            });
        });
}
```
Observe que:
 - Na instância do servidor, determinamos a utilização do `environment` "Test", devidamente definido em `appsettings.Test.Json`.
- O `secret` do `environment` deve ser o mesmo de `CommonTestUtilities/Cryptography/PasswordEncrypterBuilder` para a integridade na continuidade dos testes.
- Verificamos se existe configuração do `dbContext` que utilizaremos e se existir deletamos ela para criar nossa instância de teste.
- `buildamos` o `provider`  do `EfInMemory` e configuramos os `services` para utilizar o banco em memória.