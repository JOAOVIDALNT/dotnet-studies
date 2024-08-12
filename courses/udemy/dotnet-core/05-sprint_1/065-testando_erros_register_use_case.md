
### Cobertura de erros
Testes de erros são muito importantes e por isso precisamos garantir a maior cobertura de erros possível.

##### Exemplo:
No método Validate de RegisterUserUseCase, temos algumas condicionais: 
```csharp
private async Task Validate(RequestRegisterUserJson request)
{
    var validator = new RegisterUserValidator();

    var result = validator.Validate(request);

    var emailExists = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

    if (emailExists)
    {
        result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, Exceptions.ResourceMessagesException.EMAIL_ALREADY_REGISTERED));
    }

    if (!result.IsValid)
    {
        var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

        throw new ErrorOnValidationException(errorMessages);
    }
}
```

### Cobrindo erro de e-mail existente
Para testar o UseCase de RegisterUser, precisamos cobrir todas as validações possíveis e pra isso realizaremos o seguinte ajuste no mock do UserReadOnlyRepositoryBuilder:

```csharp
public void ExistActiveUserWithEmail(string email)
{
    _repository.Setup(repo => repo.ExistActiveUserWithEmail(email)).ReturnsAsync(true);
}
```

Setup, é um método de objetos Mock, dentro dele executamos o método mock desejado e definimos o retorno, que nesse caso é de email já existente, ou seja, definimos que para a instância atual do Mock, quando o e-mail for o informado o retorno deve ser true.

```csharp
var emailExists = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
```

#### Ajustando CreateUseCase
Para seguir com a validação do email, precisamos passar a informação pro mock, poderíamos fixar essa informação no Setup ao invés de passar o parâmetro e também poderíamos definir como qualquer:
```csharp
_repository.Setup(repo => repo.ExistActiveUserWithEmail("joao@gmail.com"));
_repository.Setup(repo => repo.ExistActiveUserWithEmail(It.IsAny<string>()));
```
Mas queremos que isso seja dinâmico então continuaremos passando através do parâmetro, para isso devemos realizar o seguinte ajuste:
```csharp
        private RegisterUserUseCase CreateUseCase(string? email = null)
        {
            var mapper = MapperBuilder.Build();
            var passwordEncrypter = PasswordEncrypterBuilder.Build();
            var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var readRepository = new UserReadOnlyRepositoryBuilder();

            if (!string.IsNullOrEmpty(email))
                readRepository.ExistActiveUserWithEmail(email);

            return new RegisterUserUseCase(readRepository.Build(), writeRepository, mapper, passwordEncrypter, unitOfWork);
        }
```
Observe que nosso readRepository agora só builda na hora de retornar o UseCase, e antes de retornar conferimos se o parâmetro opcional "email" está preenchido, se estiver realizamos a conferência do mock. 
Atente-se para o fato de que esse é um teste de retorno mockado, ou seja não vai ser feito em outro módulo.

#### Validando erro
Com tudo configurado, já podemos construir o método de teste:
```csharp
[Fact]
public async Task Error_Email_Already_Registered()
{
    var request = RequestRegisterUserJsonBuilder.Build();

    var useCase = CreateUseCase(request.Email);

    Func<Task> act = async () => await useCase.Execute(request);

    await act.Should().ThrowAsync<ErrorOnValidationException>();
}
```
Observe que:
- A variável act guarda uma função, que só é executada na próxima linha.
- Validamos que o tipo de exceção lançada deve ser a mesma do caso de não validação:
```csharp
if (!result.IsValid)
    {
        var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

        throw new ErrorOnValidationException(errorMessages);
    }
```

##### Refinando validação
No fim, ainda podemos especificar detalhes do que esperamos. Com a seguinte adição:
```csharp
(await act.Should().ThrowAsync<ErrorOnValidationException>())
    .Where(e => e.ErrorMessages.Count == 1 && e.ErrorMessages.Contains(ResourceMessagesException.EMAIL_ALREADY_REGISTERED));
```
Observe que:
- Fechamos os parênteses no await para que as funções a seguir não se tratem da Task mas sim do resultado.
- Validamos se o erro é único, utilizando o count pois o Sould().ContainSingle() do FluentAssertions não é válido dentro do Where.

### Cobrindo nome vazio
Para testar se o nome é vazio, utilizaremos praticamente a mesma estrutura da validação de email já existente, com algumas ressalvas:
```csharp
[Fact]
public async Task Error_Name_Empty()
{
    var request = RequestRegisterUserJsonBuilder.Build();
    request.Name = string.Empty;

    var useCase = CreateUseCase();

    Func<Task> act = async () => await useCase.Execute(request);

    (await act.Should().ThrowAsync<ErrorOnValidationException>())
        .Where(e => e.ErrorMessages.Count == 1 && e.ErrorMessages.Contains(ResourceMessagesException.NAME_EMPTY));
}
```
- No CreateUseCase() não queremos definir que nenhum email retornará true na verificação do mock, com isso a validação deve retornar o valor padrão (false) e o email não vai ser objeto de um teste de erro
- Limpamos o nome do resquest para garantir que ele será vazio e deve ser validado com erro
- A mensagem esperada continua sendo única mas agora deve ser do tipo NAME_EMPTY

#### Necessidade de mais validações?
O teste de nome vazio já foi um teste aplicado nos testes do validator, por que fizemos de novo aqui?
	Segundo o Werley, ele prefere realizar pelo menos um caso de teste de validação fora do real escopo de validação em useCases que utilizam essa validação. Esse foi o caso da validação de nome vazio.