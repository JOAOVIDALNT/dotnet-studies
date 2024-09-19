
Para login, utilizaremos a seguinte estrutura: `Login/DoLogin/IDoLoginUseCase` e faremos isso, pois para login, também aplicaremos, login com o Google, esqueci minha senha e etc..

#### Login Inválido
Começaremos implementando as exceções para login inválido, para este caso, não usaremos `Validator` para verificar se o e-mail é válido, mas essa é uma #sugestão para uma possível melhoria, pois em uma aplicação com vários usuários é melhor filtrar para diminuir o número de requisições inúteis em nossa base.

Agora, voltando ao código, teremos a seguinte implementação no `UseCase`:
```csharp
public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
{
    var password = _passwordEncrypter.Encrypt(request.Password);

    var user = await _readOnlyRepository.GetByEmailAndPassword(request.Email, password) ?? throw new InvalidLoginException();

    return new ResponseRegisteredUserJson
    {
        Name = user.Name
    };
}
```
Observe que:
- Estamos comparando a mesma senha criptografada, que deve gerar o mesmo resultado.
- Utilizamos o `NullChecker` na operação de consulta, para lançar a exceção, pois sabemos que se não houver usuário na base as informações de login estão inválidas.

#### Classes de Exceção
Assim ficou a classe de `InvalidLoginException`:
```csharp
public class InvalidLoginException : MyCookBookException
{
    public InvalidLoginException() : base(ResourceMessagesException.INVALID_LOGIN)
    {
    }
}
```
Observe que:
- Login inválido vai ter sempre uma mensagem fixa, pois não detalhamos erros de login por segurança
- Essa mensagem é passada para a nossa herança, que antes não recebia mensagem:
```csharp
public MyCookBookException(string message) : base(message) { }
```
- Assim, ajustamos o construtor de `MyCookBookException` para que ele passe a mensagem para `SystemException`
- Isso quebra outras exceções, como a de validação que instância uma lista, para ajustar, basta passar uma mensagem vazia, visto que no filtro de exceções vamos atribuir valor para todas essas exceções tratadas.
```csharp
public ErrorOnValidationException(IList<string> errorsMessages) : base(string.Empty)
{
    ErrorMessages = errorsMessages;
}
```

#### Filtro de Exceções
No nosso filtro de exceções, vamos tratar a exceção da seguinte maneira:
```csharp
private static void HandleProjectException(ExceptionContext context)
{
    if (context.Exception is ErrorOnValidationException)
    {
        var exception = context.Exception as ErrorOnValidationException;

        context.HttpContext.Response.StatusCode =  (int)HttpStatusCode.BadRequest;
        context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception!.ErrorMessages));
    }
    else if (context.Exception is InvalidLoginException)
    {
        var exception = context.Exception as InvalidLoginException;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(context.Exception.Message));
    }
}
```
Observe que:
- Utilizamos a estrutura `else if` pois apenas 1 tipo de exceção vai ser validado, então se a execução entrar no primeiro escopo, não precisa verificar o segundo.
- Atribuímos o valor da mensagem no próprio contexto ao `ResponseErrorJson` pois a mensagem é única e fixa, e já foi atribuída no construtor da exceção.