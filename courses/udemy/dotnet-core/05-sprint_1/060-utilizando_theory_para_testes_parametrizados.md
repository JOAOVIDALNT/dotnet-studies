A anotação Theory disponibiliza testes um pouco mais complexos do que o Fact, podendo utilizar-se de um looping, por exemplo, que é o que vamos realizar para validar a senha.


### Parâmetro opcional no builder
Antes de validar a senha, vamos definir um parâmetro no builder de CommonTestUtilities.Requests.RequestRegisterUserJson.Build().

```csharp
public static RequestRegisterUserJson Build(int passwordLength = 10)
{
    return new Faker<RequestRegisterUserJson>()
        .RuleFor(user => user.Name, (f) => f.Person.FirstName)
        .RuleFor(user => user.Email, (f, u) => f.Internet.Email(u.Name))
        .RuleFor(user => user.Password, (f) => f.Internet.Password());
}
```

Importante ressaltar que o método Password() de Bogus.DataSets.Internet.Password(), que gera senhas aleatórias, já tem o valor padrão de 10, caso o build seja instanciado sem parâmetro, ele deve gerar normalmente e caso seja especificado ele deve seguir a orientação por convenção de nomemclatura.


### Utilizando o Theory

No nosso teste para senha válida, primeiro anotaremos o método com o [Theory] e depois adicionaremos a anotação [InlineData()] que pode ser repetida e deve instruir o código a executar com cada parâmetro passado.

```csharp
[Theory]
[InlineData(0)]
[InlineData(1)]
[InlineData(2)]
[InlineData(3)]
[InlineData(4)]
[InlineData(5)]
public void Error_Password_Invalid(int passwordLength)
{
    // ARRANGE
    var validator = new RegisterUserValidator();
    var request = RequestRegisterUserJsonBuilder.Build(passwordLength);
    request.Email = "email.com";

    // ACT
    var result = validator.Validate(request);

    // ASSERT
    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.PASSWORD_LENGTH));
}
```
Neste caso, estamos testando todas os cenários onde o tamanho da senha é menor do que 6, que é o que validamos. O teste deve rodar 6 vezes.

Os valores atribuídos ao InlineData() devem seguir os parâmetros do método, ou seja, podemos adicionar parâmetros e testar com múltiplas informações:
```csharp
[InlineData(5, true)]
public void Error_Password_Invalid(int passwordLength, bool teste)
```



### Observações adicionais

- Laços, condicionais e etc não são boas práticas para testes, pra isso utilizamos o Theory
- Todo teste é independente, vai consumir tudo aquilo que ele precisa e não vai dispor de construtor ou nada do tipo.