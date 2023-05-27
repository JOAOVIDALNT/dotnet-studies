## DOTNET API
### Response overview
- ProducesResponseType data annotation could either receive an status number or an constant that describe this status
```csharp

public class Example
{

	[ProducesResponseType(200)]
	[ProducesResponseType(StatusCodes.200OK)]
	[ProducesResponseType(400)]
	[ProducesResponseType(StatusCodes.400BadRequest)]
	public ActionResult<Test> getById(int id)
	{
		...
		return Ok(entity);
	}

}

```

- The main propose of ResponseType is to document the Responses, so at swagger we have:	
<img src="assets/"
