
Recuperaremos o valor de secretKey para o nosso password encrypter e passaremos ele na injeção da classe. Para isso, primeiro adicionaremos a seção no nosso appsettings:
```json
{
  "ConnectionStrings": {
    "DataBaseType": "0",
    "HomologConn": "Server=localhost\\sqlexpress;Initial Catalog=MyCookBook;Integrated Security=True;TrustServerCertificate=True",
    "ProdConn": "Server=localhost\\sqlexpress;Initial Catalog=MyCookBook;Integrated Security=True;TrustServerCertificate=True"
  },
  "Settings": {
    "Password": {
      "SecretKey": "\"y£7W+\\@\"^?u+2#+0<IuW\""
    }
  }
}
```

Logo após, adicionamos a variável privada e a referência no construtor para injeção:
```csharp
private readonly string _secretKey;

public PasswordEncrypter(string secretKey) => _secretKey = secretKey;
```

E ai sim, podemos ajustar o AddPasswordEncrypter do DI Extension de Application:
```csharp
private static void AddPasswordEncrypter(IServiceCollection services, IConfiguration config)
{
    var secretKey = config.GetSection("Settings:Password:SecretKey").Value;
    services.AddScoped(option => new PasswordEncrypter(secretKey!));
}
```
- Para Application, precisamos instalar o pacote nugget Microsoft.Extensions.Configuration, para poder associar o IConfiguration.
- Observe também que o GetSection, retorna um objeto que transformamos em string com o .'Value'. Acontece que a melhor abordagem é utilizar o "GetValue<>" de Microsoft.Extensions.Configuration.Binder.
- Observe que utilizamos a exclamação em um possível nulo quando garantimos que haverá retorno
```csharp
var secretKey = config.GetValue<string>("Settings:Password:SecretKey");
```