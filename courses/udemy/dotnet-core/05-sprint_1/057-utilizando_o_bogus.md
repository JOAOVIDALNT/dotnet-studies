
Nesta aula, utilizaremos o bogus para a criação de testes com dados falsos.

Antes de instalar, estruturaremos o builder da request:
```csharp
namespace CommonTestUtilities.Requests
{
    public class RequestRegisterUserJsonBuilder
    {
        public static RequestRegisterUserJson Build()
        {
            return new RequestRegisterUserJson()
            {

            };
        }
    }
}
```
Observe que criamos a estrutura dentro de CommonTestUtilities e instanciaremos as requests em RegisterUserValidatorTest através do método estático Build():
```csharp
// ARRANGE
var validator = new RegisterUserValidator();
var request = RequestRegisterUserJsonBuilder.Build();

// ACT
var result = validator.Validate(request);
```

### Conhecendo o Bogus (laele)

Através da documentação do bogus no github: https://github.com/bchavez/Bogus
Podemos conferir algumas das suas diversas funcionalidades, para emular atributos da internet, temos as seguintes:
- **`Internet`**
    - `Avatar` - Generates a legit Internet URL avatar from twitter accounts.
    - `Email` - Generates an email address.
    - `ExampleEmail` - Generates an example email with @example.com.
    - `UserName` - Generates user names.
    - `UserNameUnicode` - Generates a user name preserving Unicode characters.
    - `DomainName` - Generates a random domain name.
    - `DomainWord` - Generates a domain word used for domain names.
    - `DomainSuffix` - Generates a domain name suffix like .com, .net, .org
    - `Ip` - Gets a random IPv4 address string.
    - `Port` - Generates a random port number.
    - `IpAddress` - Gets a random IPv4 IPAddress type.
    - `IpEndPoint` - Gets a random IPv4 IPEndPoint.
    - `Ipv6` - Generates a random IPv6 address string.
    - `Ipv6Address` - Generate a random IPv6 IPAddress type.
    - `Ipv6EndPoint` - Gets a random IPv6 IPEndPoint.
    - `UserAgent` - Generates a random user agent.
    - `Mac` - Gets a random mac address.
    - `Password` - Generates a random password.
    - `Color` - Gets a random aesthetically pleasing color near the base RGB. See [here](http://stackoverflow.com/questions/43044/algorithm-to-randomly-generate-an-aesthetically-pleasing-color-palette).
    - `Protocol` - Returns a random protocol. HTTP or HTTPS.
    - `Url` - Generates a random URL.
    - `UrlWithPath` - Get an absolute URL with random path.
    - `UrlRootedPath` - Get a rooted URL path like: /foo/bar. Optionally with file extension.

Também temos funcionalidades como nome e telefone:
- **`Name`**
    - `FirstName` - Get a first name. Getting a gender specific name is only supported on locales that support it.
    - `LastName` - Get a last name. Getting a gender specific name is only supported on locales that support it.
    - `FullName` - Get a full name, concatenation of calling FirstName and LastName.
    - `Prefix` - Gets a random prefix for a name.
    - `Suffix` - Gets a random suffix for a name.
    - `FindName` - Gets a full name.
    - `JobTitle` - Gets a random job title.
    - `JobDescriptor` - Get a job description.
    - `JobArea` - Get a job area expertise.
    - `JobType` - Get a type of job.
- **`Phone`**
    - `PhoneNumber` - Get a phone number.
    - `PhoneNumberFormat` - Gets a phone number based on the locale's phone_number.formats[] array index.


### Utilizando o Bogus
Na prática, o Bogus é muito inspirado no FluentValidator, isso ficará explícito ao declarar um novo request e definir suas regras com RuleFor:

```csharp
public static RequestRegisterUserJson Build()
{
    return new Faker<RequestRegisterUserJson>()
        .RuleFor(user => user.Name, (f) => f.Person.FirstName)
        .RuleFor(user => user.Email, (f, u) => f.Internet.Email(u.Name))
        .RuleFor(user => user.Password, (f) => f.Internet.Password());
}
```
Observe que:
- Como segundo parâmetro do RuleFor de Bogus.Faker, convocamos o faker através de uma função lambda.
- Na instância de e-mail poderiamos ter utilizado o Email de Person.Email mas optamos pelo Email de internet, que diferente do de Person, é uma função. Ela recebe alguns parâmetros, como FirstName, Provider (@gmail.com) e Sufixo. Neste caso estamos utilizando uma segunda variável dentro do objeto de faker, para pegar valores da instância atual e atribuir ao e-mail.