
Para os erros de integração de `RegisterUser` também faremos apenas para 1 campo, visto que nosso teste de validação faz para os outros.

### Anotação `ClassData`

Além do erro, queremos também validar o idioma do retorno, visto que aplicamos isso na nossa API. Para esta validação, utilizaremos a anotação `ClassData` junto com a anotação `Theory`.

Previamente, utilizamos `Theory` para validar um `range` de `passwordLength` nos testes de validação:
```csharp
[Theory]
[InlineData(0)]
[InlineData(1)]
[InlineData(2)]
[InlineData(3)]
[InlineData(4)]
[InlineData(5)]
public void Error_Password_Invalid(int passwordLength)
```

Com a anotação `classData`, nós atribuímos a função de iterar esses dados para uma classe, o que pode nos ajudar visto que vários testes podem validar o idioma de retorno e ao adicionar ou remover um idioma da aplicação, queremos mudar em apenas 1 ponto:
```csharp
[Theory]
[ClassData(typeof(CultureInlineDataTest))]
public async Task Error_Empty_Name(string culture)
```

#### `Classe`

A responsável deverá estender de `IEnumerable<out T>` e implementar 2 métodos obrigatórios:

```csharp
namespace WebApi.Test.InlineData
{
    public class CultureInlineDataTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "en" };
            yield return new object[] { "pt-BR" };
            yield return new object[] { "pt-PT" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
```
Observe que:
- O segundo método que é o `Get` da classe, nós chamamos o método com a implementação do que queremos varrer.
- Estamos retornando um enumerador com `Arrays` do tipo `object`, ou seja, podemos ter além de 1 único valor dentro de cada propriedade desse enumerador.
- 


### Requisição
Antes de enviar a requisição no teste que validará os idiomas de retorno, precisamos garantir que o `DefaultRequestHeader` tenha a informação válida para `Accept-Language`. Para isso, antes de enviar a requisição, adicionamos o seguinte trecho:

```csharp
if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
    _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

_httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

var response = await _httpClient.PostAsJsonAsync("api/User", request);
```


### Prefixo `yield`
O prefixo `yield` determina que a aplicação deve continuar a execução após aquele retorno. 
O método é tratado como um gerador, permitindo que você retorne uma série de valores um de cada vez.

Neste caso, `GetEnumerator` retorna um `IEnumerator<object[]>`. Cada chamada a `yield return` fornece um novo conjunto de dados para o teste.

##### Como Funciona

1. **Definição da Classe de Dados**: A classe `CultureInlineDataTest` implementa `IEnumerable<object[]>`. Dentro dela, o método `GetEnumerator` utiliza `yield return` para gerar uma lista de conjuntos de dados.
    
2. **Uso com `[ClassData]`**: A anotação `[ClassData(typeof(CultureInlineDataTest))]` indica que o xUnit deve usar a classe `CultureInlineDataTest` para obter os dados do teste. O `xUnit` vai chamar `GetEnumerator` na classe `CultureInlineDataTest` e iterar sobre cada conjunto de dados fornecido.
    
3. **Execução dos Testes**: Para cada conjunto de dados retornado, o `xUnit`  executa o método de teste (`TestCulture` neste caso) com os dados fornecidos. Portanto, o método de teste será executado três vezes: uma para cada conjunto de dados (`"en"`, `"pt-BR"`, `"pt-PT"`).

