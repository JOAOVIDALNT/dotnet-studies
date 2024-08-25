
Ainda no teste de RegisterUserUseCase, observe que ainda teremos problema na instância pois a classe tem diversas depêndencias:
```csharp
namespace UseCases.Test.User.Register
{
    public class RegisterUserUseCaseTest
    {
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = new RegisterUserUseCase();

            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
        }
    }
}
```
```csharp
public RegisterUserUseCase(IUserReadOnlyRepository userReadOnlyRepository,
    IUserWriteOnlyRepository userWriteOnlyRepository, IMapper mapper, PasswordEncrypter passwordEncrypter,
    IUnitOfWork uow)
{
    _userReadOnlyRepository = userReadOnlyRepository;
    _userWriteOnlyRepository = userWriteOnlyRepository;
    _mapper = mapper;
    _uow = uow;
    _passwordEncrypter = passwordEncrypter;
}
```

Dessas dependências, as únicas instâncias reais que utilizaremos serão:
- Mapper
- PasswordEncripter
Para os repositórios criaremos mocks (implementações fakes).


### Construindo as dependências em CommonTestUtilities
Para construir essas dependências, utilizaremos classes construtoras.

#### Passo 1
Adicionar referência de projeto de Application em CommonTestUtilities

#### Passo 2
Criar builders de Mapper no projeto de CommonTestUtilities:

```csharp
namespace CommonTestUtilities.Mapper
{
    public class MapperBuilder
    {
        public static IMapper Build()
        {
            return new MapperConfiguration(options =>
            {
                options.AddProfile(new MappingConfig());
            }).CreateMapper();
        }
    }
}
```
Observe que o nosso build tem o mesmo retorno do AddAutoMapper no nosso DIExtension de Application:
```csharp
private static void AddAutoMapper(IServiceCollection services)
{
    services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
    {
        options.AddProfile(new MappingConfig());
    }).CreateMapper());
}
```

Ambos referenciam o MappingConfig, também de Application:
```csharp
namespace MyCookBook.Application.Services.AutoMapper
{
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUserJson, Domain.Entities.User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
```

#### Passo 3
Adicionar o builder de PasswordEncrypter no CommonTestUtilities:

```csharp
namespace CommonTestUtilities.Cryptography
{
    public class PasswordEncrypterBuilder
    {
        public static PasswordEncrypter Build() => new PasswordEncrypter("abcd1234");
    }
}
```

Observe que estamos apenas construindo a instância de PasswordEncrypter, para que na execução do teste possamos utilizar dos métodos com o nosso construtor. O construtor de PasswordEncrypter é bem simples e recebe apenas a SecretKey:

```csharp
private readonly string _secretKey;

public PasswordEncrypter(string secretKey) => _secretKey = secretKey;
```

No DIExtension de Application, adicionamos o serviço da mesma forma:
```csharp
private static void AddPasswordEncrypter(IServiceCollection services, IConfiguration config)
{
    var secretKey = config.GetValue<string>("Settings:Password:SecretKey");
    services.AddScoped(option => new PasswordEncrypter(secretKey!));
}
```