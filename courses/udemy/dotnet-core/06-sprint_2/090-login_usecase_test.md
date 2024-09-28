Assim ficou a classe de teste do `useCase` de login:

```csharp
public class DoLoginUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        (var user, var password) = UserBuilder.Build();

        var useCase = CreateUseCase();

        var result = await useCase.Execute(new RequestLoginJson
        {
            Email = user.Email,
            Password = password
        });

        result.Should().NotBeNull();
        result.Name.Should().NotBeNullOrWhiteSpace().And.Be(user.Name);
    }

    [Fact]
    public async Task Error_Invalid_User()
    {
        var request = RequestLoginJsonBuilder.Build();

        var useCase = CreateUseCase();

        Func<Task> act = async () => await useCase.Execute(request);

        await act.Should().ThrowAsync<InvalidLoginException>()
            .Where(e => e.Message.Equals(ResourceMessagesException.INVALID_LOGIN));
    }

    private static DoLoginUseCase CreateUseCase(MyCookBook.Domain.Entities.User? user = null)
    {
        var passwordEncrypter = PasswordEncrypterBuilder.Build();
        var userReadOnlyRepositoryBuilder = new UserReadOnlyRepositoryBuilder();

        if (user is not null)
            userReadOnlyRepositoryBuilder.GetByEmailAndPassword(user);

        return new DoLoginUseCase(userReadOnlyRepositoryBuilder.Build(), passwordEncrypter);
    }
}
```
Observe que:
- Para testar o erro, criamos o `useCase` sem passar usuário, então o repositório não vai encontrar o usuário determinado.

Adicionamos o método de validação de usuário no `builder` do repositório:
```csharp
public void GetByEmailAndPassword(User user)
{
    _repository.Setup(repo => repo.GetByEmailAndPassword(user.Email, user.Password)).ReturnsAsync(user);
}
```

Para construir o usuário, criptografar a senha e ter acesso a ela descriptografada, no `builder` do usuário, podemos retornar 2 valores:
```csharp
namespace CommonTestUtilities.Entities
{
    public class UserBuilder
    {
        public static (User user, string password) Build()
        {
            var passwordEncrypter = PasswordEncrypterBuilder.Build();

            var password = new Faker().Internet.Password();

            var user = new Faker<User>()
                .RuleFor(u => u.Id, () => 1)
                .RuleFor(u => u.Name, (f) => f.Person.FirstName)
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
                .RuleFor(u => u.Email, (f) => passwordEncrypter.Encrypt(password));

            return (user, password);
        }
    }
}
```

Esses valores tanto podem ser assumido por 2 variáveis, como fizemos
```csharp
(var user, var password) = UserBuilder.Build();
```
Quanto por uma variável apenas:
```csharp
var user = UserBuilder.Build();
// nesse caso, acessariamos por user.user.Email e user.passord
```