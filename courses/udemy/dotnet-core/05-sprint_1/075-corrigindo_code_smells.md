Na aba  `code->issues->maintainability` podemos corrigir os `code smells`, aqui está um exemplo, que tanto o `SonarCloud` quanto o `visual studio` nos avisa:

![[Pasted image 20240823202719.png]]
`HandleProjectException` poderia ter sido marcado como estático. Lembrando que esse é um `code smell` que o próprio `vs` sinaliza:
![[Pasted image 20240823202844.png]]

O mesmo serve para essa `Exception` que pode ser nula:
![[Pasted image 20240823203150.png]]

Como no código há garantias de que haverá exceção, podemos adicionar uma '!' exclamação:
```csharp
private static void HandleProjectException(ExceptionContext context)
{
    if (context.Exception is ErrorOnValidationException)
    {
        var exception = context.Exception as ErrorOnValidationException;

        context.HttpContext.Response.StatusCode =  (int)HttpStatusCode.BadRequest;
        context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception!.ErrorMessages));
    }
}
```

### INFORMAÇÕES
Nos problemas, podemos acessar as informações de, por exemplo: por que é um problema e outras funções:
![[Pasted image 20240823203604.png]]

### DICAS
O `SonarCloud` te dá dicas com exemplos, nesse caso, por exemplo:
![[Pasted image 20240823204247.png]]
ele indica que em `api->middleware->cultureMiddleware` deveríamos utilizar o `.Exists` ao invés de `.any()`.
Corrigiremos no código, mas antes, faremos com que `supportedLanguages` deixe de ser um `array` pois a segunda opção, evidencia que `array` tem uma implementação mais complicada para `Exists`:
![[Pasted image 20240823204452.png]]