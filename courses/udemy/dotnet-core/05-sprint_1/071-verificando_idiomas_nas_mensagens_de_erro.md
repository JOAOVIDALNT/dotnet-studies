
Para que a cada validação de cultura que o nosso teste roda, nós façamos a comparação com o idioma correto, aplicaremos a seguinte lógica no teste:
```csharp
var expectedMessage = ResourceMessagesException.ResourceManager.GetString("NAME_EMPTY", new CultureInfo(culture));

errors.Should().ContainSingle().And.Contain(error => error.GetString().Equals(expectedMessage));
```
Observe que:
- Ao invés de buscar a mensagem apenas através do `ResourceMessagesException.NAME_EMPTY` que considera o idioma do ambiente para trazer a mensagem, estamos acessando o `ResourceManager` e trazendo o campo de acordo com o `CultureInfo`, que é o parâmetro do `DataClass` no nosso método de teste.

#### Resultado do teste de erro
Por fim, nosso teste de erro ficou assim:
```csharp
[Theory]
[ClassData(typeof(CultureInlineDataTest))]
public async Task Error_Empty_Name(string culture)
{
    var request = RequestRegisterUserJsonBuilder.Build();
    request.Name = string.Empty;

    if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
        _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

    _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

    var response = await _httpClient.PostAsJsonAsync("api/User", request);

    response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

    await using var responseBody = await response.Content.ReadAsStreamAsync();

    var responseData = await JsonDocument.ParseAsync(responseBody);

    var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();

    var expectedMessage = ResourceMessagesException.ResourceManager.GetString("NAME_EMPTY", new CultureInfo(culture));

    errors.Should().ContainSingle().And.Contain(error => error.GetString().Equals(expectedMessage));
}
```