Para remover todos os possíveis espaços em branco desnecessários das requisições, utilizaremos um `StringConverter`. Para isso, teremos uma classe que herda da classe abstrata `JsonConverter`:

```csharp
public partial class StringConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString()?.Trim();

        if (value == null) 
            return null;

        return RemoveExtraWhiteSpaces().Replace(value, " ");
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) => writer.WriteStringValue(value);

    [GeneratedRegex(@"\s+")]
    private static partial Regex RemoveExtraWhiteSpaces();
}
```
Observe que:
- Não manipulamos o método  `write`, apenas retornamos o valor padrão
- No `Read`, primeiro removemos os espaços o inicio e final com `trim()`, utilizando o sufixo `?` para garantir que só executaremos o `trim` se o valor não for nulo.
- E por fim, executamos um `regex`, de valor `@"\s+"` que retorna todos os grupos de espaço no texto, após isso executamos o `Replace` para que cada possível grupo de espaço, se torne um espaço único.


Para aplicar a validação na aplicação, basta adicionar a seguinte configuração ao `Program.cs`:
```csharp
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new StringConverter()));
```
Com isso, a conversão deve ser realizada no intermédio da requisição, antes de entrar no `controller`.