
### Testes com `xUnit`
Através do `xUnit`, veremos como lidar com testes unitários e de integração.

#### Testes unitários
Testes unitários, tem uma estrutura básica definida em 3 etapas claras:
- ARRANGE -> Preparação
- ACT -> Ação
- ASSERT -> Validação

Na preparação declaramos as entidades e variáveis, na ação executamos as funções delas e na validação garantimos que tivemos os resultados esperados.

##### EXEMPLO
```csharp
[Fact]
public void Success()
{
    // ARRANGE
    var validator = new RegisterUserValidator();
    var request = RequestRegisterUserJsonBuilder.Build();

    // ACT
    var result = validator.Validate(request);

    // ASSERT
    result.IsValid.Should().BeTrue();
}
```
Este é um exemplo de teste de sucesso na validação de uma requisição para cadastro de usuário.
Observe que:
- A anotação `[Fact]` indica que dentro do projeto `xUnit`, aquele método é um teste.
- `RequestRegisterJsonBuider` é um de validação implementado com a biblioteca `Bogus`
- Para casos de testes de validação, que não salvam dados, utilizamos as instâncias reais das funções, como no caso do `Validate` da classe de aplicação `RegisterUserValidator`.

###### Teste de erro
```csharp
[Fact]
public void Error_Email_Empty()
{
    // ARRANGE
    var validator = new RegisterUserValidator();
    var request = RequestRegisterUserJsonBuilder.Build();
    request.Email = string.Empty;

    // ACT
    var result = validator.Validate(request);

    // ASSERT
    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.EMAIL_EMPTY));
}
```

###### Teste com `Theory`
```csharp
[Theory]
[InlineData(1)]
[InlineData(3)]
[InlineData(5)]
public void Error_Password_Invalid(int passwordLength)
{
    // ARRANGE
    var validator = new RegisterUserValidator();
    var request = RequestRegisterUserJsonBuilder.Build(passwordLength);

    // ACT
    var result = validator.Validate(request);

    // ASSERT
    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.PASSWORD_LENGTH));
}
```
Observe que:
- Com o `Theory` podemos repetir o teste utilizando diferentes parâmetros, que podem ter mais de um valor
- Os parâmetros `InlineData` são diretamente associados aos parâmetros do método
- O `Theory` executa para todos os parâmetros passados

#### Testes de serviço
O teste na camada de serviços é um teste de integração. Para realizar os testes, precisamos criar a instância dos serviços para fornecer à classe `Service` além de criar `Mocks` dos repositórios para garantir que não persistiremos dados de teste.

##### `Config Builders`
Os `builders` de configuração servirão para serviços que utilizamos nos métodos que queremos testar. Para instanciar a classe `UserService` e testar o registro de usuário, por exemplo, precisamos dos builds de `IMapper` e `PasswordEncrypter`, utilizados na lógica de registro.
```csharp
namespace CommonTestUtilities.Builders.Configs
{
    public class MapperBuilder
    {
        public static IMapper Build()
        {
            return new MapperConfiguration(options =>
            {
                options.AddProfile(new MappingConfig());
            }).CreateMapper();
        }
    }
}
```
Exemplo de `build`  do `Mapper`. Observe que:
- A interface `IMapper` é retornada pelo método `CreateMapper`, trabalhar com interfaces facilita, pois teremos dai o contrato e todas as funcionalidades que estendem dele.
- A configuração é a mesma feita na injeção de dependência da camada `Application`.

```csharp
namespace CommonTestUtilities.Builders.Configs
{
    public class PasswordEncrypterBuilder
    {
        public static PasswordEncrypter Build() => new PasswordEncrypter("abcd1234");
    }
}
```
`Builder` simples do `PasswordEncrypter`.

##### `Mock Builders`
Os `Mock Builders` são instâncias `mock` (`biblioteca moq)` das nossas interfaces de persistência de dados, assim podemos realizar as integrações até a última etapa nos testes.

###### Interfaces que apenas registram dados
Veja o exemplo da simples implementação de um `mock` para o repositório `IUnitOfWork`.
Lembrando que os `Mocks` não são injeção de dependência automática, eles devem ser construídos e informados na instância manual do serviço.

```csharp
namespace CommonTestUtilities.Builders.Mocks
{
    public class UnitOfWorkBuilder
    {
        public static IUnitOfWork Build()
        {
            var mock = new Mock<IUnitOfWork>();

            return mock.Object;
        }
    }
}
```
Observe que:
- O retorno deve ser o `mock.Object`
- A configuração do `mock` é simples pois a interface apenas registra e não retorna dados

###### Interfaces que retornam dados
Para interfaces que retornam dados, a configuração do `mock` é mais complexa e deve ser feita através da injeção de dependência que recebe o próprio `Mock`:

```csharp
namespace CommonTestUtilities.Builders.Mocks
{
    public class UserRepositoryBuilder
    {
        private readonly Mock<IUserRepository> _userRepository;

        public UserRepositoryBuilder() => _userRepository = new Mock<IUserRepository>();

        public IUserRepository Build() => _userRepository.Object;

        public void ExistsUserWithEmail(string email)
        {
            _userRepository.Setup(repo => repo.ExistsUserWithEmail(email)).ReturnsAsync(true);
        }
    }
}
```
Observe que:
- Precisamos refletir a consulta que queremos realizar
- Através do setup, podemos definir o retorno esperado para a ação correspondente dentro do repositório, ou seja, quando executamos o `ExistsUserWithEmail` definimos que sempre que essa instância do `mock` executar `repo => ExistsUserWithEmail` o retorno deve ser o informado em `ReturnsAsync`.


#### Testes
Para os testes de serviço, criaremos primeiro o método estático base para a instância daquele serviço:
```csharp
private static UserService CreateService(string? email = null)
{
    var mapper = MapperBuilder.Build();
    var passwordEncrypter = PasswordEncrypterBuilder.Build();
    var userRepository = new UserRepositoryBuilder();
    var unitOfWork = UnitOfWorkBuilder.Build();

    if (!string.IsNullOrEmpty(email))
    {
        userRepository.ExistsUserWithEmail(email);
    }

    return new UserService(userRepository.Build(), unitOfWork, mapper, passwordEncrypter);
}
```
Observe que:
- A instância do `builder` de `UserRepository` deve ser primeiro declarada e depois construída.
- Temos um parâmetro opcional que se preenchido, define que aquela instância do `mock`, ao executar determinada consulta, deve retornar determinado valor.
- Retornamos uma instância do serviço para ser executada no escopo do teste.

##### Sucesso
O caso de teste de sucesso continua bem simples, passamos dados que sabemos que são válidos e garantimos que o retorno deve ser o esperado.
```csharp
[Fact]
public async Task Success()
{
    var request = RegisterUserRequestBuilder.Build();

    var service = CreateService();

    var result = await service.RegisterUser(request);

    result.Should().NotBeNull();
    result.Name.Should().Be(request.Name);
}
```

##### Erro
Nos casos de erro, podemos aplicar funções mais interessantes:
```csharp
[Fact]
public async Task Error_Email_Already_Registered()
{
    var request = RegisterUserRequestBuilder.Build();

    var service = CreateService(request.Email);

    Func<Task> act = async () => await service.RegisterUser(request);

    (await act.Should().ThrowAsync<ErrorOnValidationException>())
        .Where(e => e.ErrorMessages.Count == 1 && e.ErrorMessages.Contains(ResourceMessageException.EMAIL_ALREADY_REGISTERED));
}
```
Observe que:
- A variável `act` guarda uma função, que só é executada na linha seguinte.
- O escopo da execução do `act`, ente parênteses, enfatiza que vamos tratar sobre o retorno daquela função armazenada.

Para outras operações onde esperamos erros lançados, a lógica é a mesma:
```csharp
[Fact]
public async Task Error_Name_Empty()
{
    var request = RegisterUserRequestBuilder.Build();
    request.Name = string.Empty;

    var service = CreateService();

    Func<Task> act = async () => await service.RegisterUser(request);

    (await act.Should().ThrowAsync<ErrorOnValidationException>())
        .Where(e => e.ErrorMessages.Count == 1 && e.ErrorMessages.Contains(ResourceMessageException.NAME_EMPTY));
}
```