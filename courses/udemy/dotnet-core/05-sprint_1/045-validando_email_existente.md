
Para validar se o e-mail já está registrado, consultamos a base e no retorno adicionaremos ao result de validator, que já checou os parâmetros de input do usuário, o erro e consequentemente o resultado deixará de ser válido.

```csharp
var validator = new RegisterUserValidator();

var result = validator.Validate(request);

var emailExists = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

if (emailExists)
{
    result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, Exceptions.ResourceMessagesException.EMAIL_ALREADY_REGISTERED));
}
```
O primeiro parâmetro de 'ValidationFailure' é o nome da propriedade, por isso não utilizamos.