
Basta adicionar a seguinte linha ao `program.cs` para que as `urls` sejam `lower case` por padrão: 
```csharp
builder.Services.AddRouting(options => options.LowercaseUrls = true);
```
