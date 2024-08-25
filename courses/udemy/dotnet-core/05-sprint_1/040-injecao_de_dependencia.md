
No estado atual da aplicação, já temos os métodos do nosso repositório no projeto 'Infraestructure', considerando que no padrão DDD 'Application' não deve comunicar com o projeto de 'Infraestructure' (que deve se comunicar com serviços externos, ex: SQLServer).

Nesta etapa, precisamos que 'Application' consulte os contratos (interfaces) em 'Domain' através da injeção de dependência.


### Problema na declaração do program.cs
```csharp
builder.Services.AddScoped<>();
builder.Services.AddScoped<>();
builder.Services.AddScoped<>();
```
Imagine que em um projeto grande, para cada injeção de serviço adicionaremos uma linha ao program.cs, isso tornaria o nosso código extenso e não muito intuitivo, considerando que haverão outros tipos de configuração nesse documento.

### Solução
Imagine que podemos criar um 'alias' que referência uma classe responsável por gerir essas injeções por projeto, fazendo com que o program.cs receba orientações do tipo:

```csharp
builder.Services.AddInfraestructure();
builder.Services.AddApplication();
```

- OBS -> Adicionaremos uma referência a Infraestrutura no projeto da API, idealmente segundo o DDD não deveria ser feito, mas para configurar a injeção de dependencia, precisamos fazer.
```csharp
using MyCookBook.Application;
using MyCookBook.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraestructure();
builder.Services.AddApplication();
```

### DI Extension

No projeto 'infraestructure' criaremos uma classe estática responsável pelas injeções de dependência, dentro dela, o método 'AddInfraestructure' receberá a instância atual de IServiceCollection e utilizará outros métodos estáticos para atribuir as injeções ao serviço vigente.

```csharp
namespace MyCookBook.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfraestructure(this IServiceCollection services)
        {
            AddDbContext(services);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {
            var connectionString = "";

            services.AddDbContext<MyCookBookDbContext>(options => 
            { // options manipula o base:options do contexto
                options.UseSqlServer(connectionString); //SQL package needed
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        }
    }
}
```

Criaremos o mesmo arquivo no projeto Application, para gerir suas próprias injeções:

```csharp
namespace MyCookBook.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
            AddPasswordEncrypter(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new MappingConfig());
            }).CreateMapper());
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddPasswordEncrypter(IServiceCollection services)
        {
            services.AddScoped(option => new PasswordEncrypter());
        }
    }
}
```

### DI nas classes

Para os use cases, utilizaremos a injeção de dependência padrão, via construtor:
```csharp
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IMapper _mapper;
        private readonly PasswordEncrypter _passwordEncrypter;

        public RegisterUserUseCase(IUserReadOnlyRepository userReadOnlyRepository,
            IUserWriteOnlyRepository userWriteOnlyRepository, IMapper mapper,
             PasswordEncrypter passwordEncrypter)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _mapper = mapper;
            _passwordEncrypter = passwordEncrypter;
        }
```
Exemplo da DI na classe RegisterUseCase, observe que:
	 para o PasswordEncrypter, não estamos utilizando interface, fizemos isso pois o único projeto que vai consumir a instância é o próprio 'Application'. Então não é tão obrigatório por convenção o registro e instância de Interfaces relacionadas.

### DI de UseCases nos controllers
Já para os **controllers**, principalmente nos métodos de que requisitam UseCases, utilizaremos a injeção direta nos parâmetros, anotando a interface com '[FromServices]'.

```csharp

namespace MyCookBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Register([FromServices]IRegisterUserUseCase useCase, 
            [FromBody]RequestRegisterUserJson request)
        {
            var result = useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}

```