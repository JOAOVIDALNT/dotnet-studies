
Os testes de integração, são testes realizados no controller da API. Para eles, criaremos um projeto dedicado.

#### Projeto
Em tests/ criaremos um novo xUnit project "WebApi.Test".
#### Referências de projeto
O projeto WebApi.Test deve referenciar os seguintes projetos:
- CommonTestUtilities
- API

### SETUP
#### IClassFixture
Na classe User/Register/RegisterUserTest.cs, para determinar que aquela classe realizará testes de integração, extenderemos de IClassFixture<> que recebe um servidor como parâmetro.

#### WebApplicationFactory
WebApplicationFactory, da lib Microsoft.AspNetCore.Mvc.Testing será o configurador para o servidor de IClassFixture, recebendo também um parâmetro TEntryPoint que será uma instância da classe Program do nosso projeto de API. Para isso precisamos inserir em Program.cs o seguinte trecho:
```csharp
public partial class Program { }
```

#### Implementando
Agora que já temos as instâncias definidas, podemos criar um client no servidor de IClassFixture e utiliza-lo dentro do arquivo de testes através da injeção no construtor:
```csharp
using CommonTestUtilities.Requests;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace WebApi.Test.User.Register
{
    public class RegisterUserTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public RegisterUserTest(WebApplicationFactory<Program> factory) => factory.CreateClient();

        [Fact]
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var httpClient = new HttpClient();

            await _httpClient.PostAsJsonAsync("User", request);
        }
    }
}
```