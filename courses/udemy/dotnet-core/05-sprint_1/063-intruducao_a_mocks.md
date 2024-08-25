
Para utilizar implementações falsas dos nossos repositórios, utilizaremos a biblioteca "Moq".

Mocks trabalham idealmente com Interfaces.

#### Passo 1
Criar mocks de interfaces simples, ou seja, interfaces que não tem métodos que retornam algo, pois esses casos necessitam de algumas tratativas. Já para interfaces simples como IUnitOfWork e IUserWriteOnlyRepository, basta instanciar o mock e retornar seu objeto, que é o implementação fake:

```csharp
namespace CommonTestUtilities.Repositories
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
O mesmo parra IUserWriteOnlyRepository:
```csharp
namespace CommonTestUtilities.Repositories
{
    public class UserWriteOnlyRepositoryBuilder
    {
        public static IUserWriteOnlyRepository Build()
        {
            var mock = new Mock<IUserWriteOnlyRepository>();

            return mock.Object;
        }
    }
}
```

Sendo assim, em RegisterUseCaseTest, podemos instanciar os devidos Builders: 
```csharp
var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
var unitOfWork = UnitOfWorkBuilder.Build();
```

#### Passo 2
Criando o Builder de interfaces com métodos que retornam valores:
```csharp
namespace CommonTestUtilities.Repositories
{
    public class UserReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUserReadOnlyRepository> _repository;

        public UserReadOnlyRepositoryBuilder() => _repository = new Mock<IUserReadOnlyRepository>();

        public IUserReadOnlyRepository Build() => _repository.Object;
    }
}
```
Observe que:
- O mock não pode mais ser estático

Por enquanto nosso teste de sucesso ficará assim: 
```csharp
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuilder.Build();

        var mapper = MapperBuilder.Build();
        var passwordEncrypter = PasswordEncrypterBuilder.Build();
        var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var readRepository = new UserReadOnlyRepositoryBuilder().Build();

        var useCase = new RegisterUserUseCase(readRepository, writeRepository, mapper, passwordEncrypter, unitOfWork);

        var result = await useCase.Execute(request);

        result.Should().NotBeNull();
        result.Name.Should().Be(request.Name);
    }
}
```