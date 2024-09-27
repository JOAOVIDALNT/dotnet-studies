
Para o tratamento de exceções, é ideal utilizarmos um modelo de filtragem, que pode tanto ser feito via `Middleware` quanto via `ExceptionFilter` do `Microsoft.AspNetCore.Mvc.Filters;`


### Middleware
Veja a simples implementação de um `middleware` que quer tratar exceções: 
```csharp
public class ExcecaoMiddleware
{
    private readonly RequestDelegate _next;

    public ExcecaoMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Passa a requisição adiante no pipeline
            await _next(context);
        }
        catch (Exception ex)
        {
            // Tratamento de exceção e retorno de mensagem de erro
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Configurando o tipo de conteúdo da resposta
        context.Response.ContentType = "application/json";
        
        // Configurando o código de status da resposta
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // Corpo da resposta com a mensagem de erro
        var result = JsonConvert.SerializeObject(new { message = "Ocorreu um erro no servidor", detalhe = exception.Message });

        // Escreve a mensagem de erro no corpo da resposta
        return context.Response.WriteAsync(result);
    }
}

```
Observe que:
- `Middlewares` registrados na aplicação vão executar o método `Invoke` ou `InvokeAsync`.
- `Middlewares` funcionam como `pipelines`, transferindo a execução do código através do `RequestDelegate`.
- Para o caso do `Middleare` de exceções, apenas transferimos a execução dentro de um bloco `try-catch` e que garante que qualquer erro a partir dali vai ser tradado por último, ou seja, antes de retornar para cliente, pelo filtro do `middleware`.

**Observe o tratamento de exceções personalizadas:**
```csharp
private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        if (ex is ErrorOnValidationException validationException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseErrorJson(validationException.ErrorMessages)));
        }
        else if (ex is InvalidLoginException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseErrorJson(ex.Message)));
        }
        else
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseErrorJson("Unknown error occurred.")));
        }
    }

```
- o `cast` `ex is ErrorOnValidationException validationException` permite que utilizemos a lista de erros que pertence à nossa classe personalizada.


### Filter
O `ExceptionFilter`, é um recurso do pacote `mvc` para tratar exceções. Observe a estrutura:
```csharp
public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is MyCookBookException)
            HandleProjectException(context);
        else
            ThrowUnknowException(context);
    }

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

    private static void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UNKNOW_ERROR));
    }
}
```
- A herança da classe `IExceptionFilter` obriga a implementação do `OnException` que deve ser executado sempre que há uma exceção.
- Em  `Filters` existem algumas abstrações por estarmos ligados ao `pipeline mvc` que trabalha com `ActionResults`, possibilitando, por exemplo, a manipulação do `context.Result`.

### Conslusion
Em uma aplicação podemos utilizar os dois. Reconhecendo que os `Exception Filters` serão executados primeiro, pois o `Middlware` passa a responsabilidade para as ações do controlador e caso existe um filtro de exceção, ele deve ser executado dentro da ação do controlador.


Referências [`Middleware vs Exception Filters`](https://medium.com/@engrabdullahabdullah/middleware-vs-exception-filters-in-asp-net-core-a-simplified-guide-2f00a5f1bf04)  + `ChatGPT`
