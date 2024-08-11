Nessa passo já está tudo pronto, só vamos ajustar para que a instância do UseCase seja feita através de um método auxiliar e não dentro do Test:

```csharp
[Fact]
public async Task Success()
{
    var request = RequestRegisterUserJsonBuilder.Build();

    var useCase = CreateUseCase();

    var result = await useCase.Execute(request);

    result.Should().NotBeNull();
    result.Name.Should().Be(request.Name);
}

private RegisterUserUseCase CreateUseCase()
{
    var mapper = MapperBuilder.Build();
    var passwordEncrypter = PasswordEncrypterBuilder.Build();
    var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
    var unitOfWork = UnitOfWorkBuilder.Build();
    var readRepository = new UserReadOnlyRepositoryBuilder().Build();

    return new RegisterUserUseCase(readRepository, writeRepository, mapper, passwordEncrypter, unitOfWork);
}
```
Observe que:
Na execução desse teste, o nosso mock que retorna valor (UserReadOnly) deriva de uma interface com apenas um método booleano: 
```csharp
public interface IUserReadOnlyRepository
{
    public Task<bool> ExistActiveUserWithEmail(string email);
}
```
Logo, a conferência do Email com o mock, deve retornar o valor padrão se não definirmos nada. Para esse teste, o valor padrão (false) corresponde e o teste tem êxito.