
Para entender a arquitetura das funções de teste, observe a prévia do nosso primeiro teste de sucesso para RegisterUser:

```csharp
namespace Validators.Test.User.Register
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Success()
        {
            // ARRANGE
            var validator = new RegisterUserValidator();

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid
        }
    }
}
```
A função ainda não é válida, é só um exemplo da dinâmica de testes. Observe que:
- A estrutura vai ser parecida com a do método implementado, nesse caso do exemplo foi um ctrl+c, ctrl+v.
- Iniciaremos os testes sempre com os casos de sucesso primeiro.
- Validators.Test deve ter referência para Application e CommonTestUtilities

Na próxima aula, utilizaremos a lib "Bogus" no nosso projeto de utilities para gerar requests para validação.