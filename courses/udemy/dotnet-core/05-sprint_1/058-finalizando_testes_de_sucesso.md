Nesta aula, finalizaremos os testes de sucesso com Fluent Assertions

#### Debugando testes
Para debugar testes é simples:
	Botão direito dentro da função -> Debug Tests
	![[Pasted image 20240805070322.png]]

### Passsando o primeiro teste

Com o Bogus configurado, já podemos testar nosso primeiro caso, nessa primeira tentativa utilizaremos o Assert.True com o resultado da validação do FluentValidator.
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
    Assert.True(result.IsValid);
}
```

### Utilizando o FluentAssertions
No mercado de trabalho, veremos muito o uso do FluentAssertions em detrimento do Assert nativo do xUnit. Por isso, instalaremos o nuget package FluentAssertions no nosso projeto Validator.Test e substituiremos o Assert.True:
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
