
Para os testes de integração de login, adicionamos os seguintes parâmetros ao `ConfigureWebHost` do `CustomWebApplicationFactory`:
```csharp
using var scope = services.BuildServiceProvider().CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<MyCookBookDbContext>();

dbContext.Database.EnsureDeleted();

StartDatabase(dbContext);
```
```csharp
private void StartDatabase(MyCookBookDbContext dbContext)
{
    (_user, _password) = UserBuilder.Build();

    dbContext.Users.Add(_user);

    dbContext.SaveChanges();
}
```

Aqui estamos instanciando o contexto e garantindo que não existe registro anterior, pois queremos registrar um usuário na base em memória antes de rodar o teste para logar.
Para isso, declaramos variáveis que receberão os valores do `build` de `user` na própria classe `CustomWebApplicationFactory`:
```csharp
private MyCookBook.Domain.Entities.User _user = default!;
private string _password = string.Empty;

public string GetEmail() => _user.Email;
public string GetPassword() => _password;
public string GetName() => _user.Name;
```
Observe que:
- `_user e _password` são iniciados pelo `build` de `user` que também é adicionado ao banco de dados.
- Os métodos `Get` permitirão que a nossa classe de teste acesse os valores do usuário registrado para efetuar o login com sucesso.

Observe o construtor e o método de sucesso para o teste de login:
```csharp
private readonly string _email;
private readonly string _password;
private readonly string _name;

public DoLoginTest(CustomWebApplicationFactory factory)
{
    _httpClient = factory.CreateClient();
    _email = factory.GetEmail();
    _password = factory.GetPassword();
    _name = factory.GetName();
}

[Fact]
public async Task Success()
{
    var request = new RequestLoginJson
    {
        Email = _email,
        Password = _password
    };

    var response = await _httpClient.PostAsJsonAsync(method, request);

    response.StatusCode.Should().Be(HttpStatusCode.OK);

    await using var responseBody = await response.Content.ReadAsStreamAsync();

    var responseData = await JsonDocument.ParseAsync(responseBody);

    responseData.RootElement.GetProperty("name").GetString().Should().NotBeNullOrWhiteSpace().And.Be(_name);
}
```

Observe também o caso de fracasso:
```csharp
[Theory]
[ClassData(typeof(CultureInlineDataTest))]
public async Task Error_Login_Invalid(string culture)
{
    var request = RequestLoginJsonBuilder.Build();

    if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
        _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

    _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

    var response = await _httpClient.PostAsJsonAsync(method, request);

    response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

    await using var responseBody = await response.Content.ReadAsStreamAsync();

    var responseData = await JsonDocument.ParseAsync(responseBody);

    var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();

    var expectedMessage = ResourceMessagesException.ResourceManager.GetString("INVALID_LOGIN", new CultureInfo(culture));

    errors.Should().ContainSingle().And.Contain(error => error.GetString()!.Equals(expectedMessage));
}
```
- Muito parecido com o que já é o caso de fracasso do teste de registro, por exemplo.
- Não precisa validar nada pós build pois esperamos que de fato, o resultado do build não exista na base.