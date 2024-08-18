
#### Setup anterior
Com o teste de integração previamente configurado: 
```csharp
[Fact]
public async Task Success()
{
	var request = RequestRegisterUserJsonBuilder.Build();

    var httpClient = new HttpClient();

    await _httpClient.PostAsJsonAsync("User", request);
}
```
Vamos agora validar e retorno dessa requisição.

#### Validando integração
Para validar a integração, checaremos primeiro o status code, depois o conteúdo da resposta:
```csharp
[Fact]
public async Task Success()
{
    var request = RequestRegisterUserJsonBuilder.Build();

    var httpClient = new HttpClient();

    var response = await _httpClient.PostAsJsonAsync("User", request);

    response.StatusCode.Should().Be(HttpStatusCode.Created);

    await using var responseBody = await response.Content.ReadAsStreamAsync();

    var responseData = await JsonDocument.ParseAsync(responseBody);

    responseData.RootElement.GetProperty("name").GetString().Should().NotBeNullOrWhiteSpace().And.Be(request.Name);
}
```
Observe que:
-  A declaração `using` é uma instância de `IDisposible` o que garante que o objeto seja descartado imediatamente após o bloco `using`, liberando os recursos de forma síncrona.
- Não `desserializamos` a `response` pois não estamos focando o teste na `desserialização` queremos apenas validar o conteúdo do retorno.


#### Persistência
No estado atual do código, o mock desse teste de integração está sendo salvo na nossa base de dados da aplicação e não queremos isso para testes. Na próxima aula configuraremos uma base de dados em memória para tratar isso.