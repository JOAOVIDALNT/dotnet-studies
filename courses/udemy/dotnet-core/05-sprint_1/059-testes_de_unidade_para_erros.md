
Usaremos 1 teste de unidade para cada possível erro de validação em RegisterUserValidatorTest

```csharp
public RegisterUserValidator()
{
    RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
    RuleFor(user => user.Email).NotEmpty();
    RuleFor(user => user.Email).EmailAddress();
    RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6);
}
```

### ERROR_NAME_EMPTY
```csharp
[Fact]
public void Error_Name_Empty()
{
    // ARRANGE
    var validator = new RegisterUserValidator();
    var request = RequestRegisterUserJsonBuilder.Build();
    request.Name = string.Empty;

    // ACT
    var result = validator.Validate(request);

    // ASSERT
    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.NAME_EMPTY));
}
```
Observe que:
- ContainSingle quer garantir que a propriedade contém apenas um erro, por isso estamos testando isoladamente.
- result pode ser validado em diferentes instâncias.
- Checamos se a mensagem retornada é a esperada.


### ERROR_EMAIL_EMPTY
Para o e-mail, queremos apenas copiar o teste de nome e alterar os 'alias' e para isso, precisamos garantir que o validador não retorne mais de um erro, que é o que ele faria em caso de email vazio, pois um e-mail vazio também é inválido e o FluentValidator na nossa classe RegisterUserValidator checa ambos.

Por isso, adicionaremos uma condicional na validação:
```csharp
public RegisterUserValidator()
{
    RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
    RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
    RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6);
    When(user => !string.IsNullOrEmpty(user.Email), () =>
    {
        RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
    });
}
```
Observe que
- Adicionamos a clausula When, que garante que só validaremos se o e-mail é um e-mail válido caso ele não seja vazio ou nulo.
- Adicionamos também as mensagens personalizadas que não tinhamos anteriormente

### EMAIL_INVALID
```csharp
[Fact]
public void Error_Email_Invalid()
{
    // ARRANGE
    var validator = new RegisterUserValidator();
    var request = RequestRegisterUserJsonBuilder.Build();
    request.Email = "email.com";

    // ACT
    var result = validator.Validate(request);

    // ASSERT
    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.EMAIL_INVALID));
}
```
