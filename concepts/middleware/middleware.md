### Conceito
Middlewares são ações que executam antes das requisições, através dos middlewares podemos capturar informações da requisição e a partir dai alterar a configuração da aplicação ou gerar logs, por exemplo.

### Escopo
Observe o seguinte escopo de um middleware que visa configurar a cultura da aplicação para trabalhar respostas em diferentes idiomas:

```csharp
public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var cultureInfo = new CultureInfo("en");

        if (!string.IsNullOrEmpty(requestedCulture) && supportedLanguages.Any(x => x.Name.Equals(requestedCulture)))
        {
            cultureInfo = new CultureInfo(requestedCulture);
        }

        await _next(context);
    }
}
```
Observe que:
- O middleware tem um método único, que informa através do `RequestDelegate` quando a aplicação deve seguir.
- Através do método padrão `Invoke` ou `InvokeAsync`, podemos acessar o contexto da requisição para tratar os dados.
- Veremos na configuração que a ordem de execução dos  middlewares se dá pela ordem de chamada deles no `Program.cs`
### Configuração
A configuração do Middleware é bem simples, consiste apenas na adição do serviço no `Program.cs`. Por padrão a ordem de execução dos Middlewares é definida pela sequência no arquivo de configuração.
```csharp
app.UseMiddleware<CultureMiddleware>();
```

#### Middleware condicional
Obviamente, queremos também definir alguns middlewares apenas para ações específicas, afinal, em uma aplicação grande, não queremos todos os middlewares sendo executados em sequência a cada requisição.

Para realizar a validação na execução desses middlewares, podemos utilizar as seguintes funções:

##### `MapWhen e UseWhen
```csharp
app.MapWhen(context => context.Request.Method == HttpMethods.Get, appBuilder => 
{ 
	appBuilder.UseMiddleware<MyMiddleware>(); 
});
```
Aqui definimos que um middleware só será executado quando o método da requisição for do tipo `GET`.
O mesmo pode ser aplicado para a função `UseWhen`.


##### `Map` em rotas específicas
Para utilizar middlewares em rotas específicas, utilizarmos o `Map`, como no exemplo:
```csharp
app.Map("/example", appBuilder =>
{
    appBuilder.UseMiddleware<MyMiddleware>();
    appBuilder.Run(async context =>
    {
        await context.Response.WriteAsync("This is the /example endpoint.");
    });
});
```

Também podemos aplicar uma condicional de rotas no `MapWhen` e realizar a mesma função:
```csharp
app.MapWhen(context => context.Request.Path.StartsWithSegments("/example"), appBuilder =>
{
    appBuilder.UseMiddleware<MyMiddleware>();
    appBuilder.Run(async context =>
    {
        await context.Response.WriteAsync("This is the /example endpoint.");
    });
});
```

Além disso, é possível utilizar o middleware e condicionar dentro dele mesmo:
```csharp
public class MyMiddleware
{
    private readonly RequestDelegate _next;

    public MyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/example"))
        {
            // Lógica específica para a rota /example
        }

        await _next(context);
    }
}

// No Program.cs
app.UseMiddleware<MyMiddleware>();

app.MapGet("/example", async context =>
{
    await context.Response.WriteAsync("This is the /example endpoint.");
});

```
