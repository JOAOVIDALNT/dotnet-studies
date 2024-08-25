
Começamos criando um novo projeto tipo xUnit Test Project "UseCases.Test" e referenciando os projetos CommonTestUtilities e Application, além de instalar o pacote FluentAssertions.

Pro nosso primeiro teste, sempre de sucesso, vamos validar 2 coisinhas:
```csharp
namespace UseCases.Test.User.Register
{
    public class RegisterUserUseCaseTest
    {
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = new RegisterUserUseCase();

            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
        }
    }
}
```
Observe que:
- estamos tentando instanciar RegisterUserUseCase, o que não vai funcionar sem DI. A não ser que passemos os parâmetros. Mas por enquanto estamos apenas estruturando o teste e não vamos rodar.
- Estamos validando se Name de result (único atributo do retorno por enquanto) é igual ao Name de request. Pra isso devemos mudar o retorno no Execute, para que ele retorne o Name de user que foi mapeado com o AutoMapper e não o name do request.

Ajuste para a instância do UseCase na próxima aula ->
