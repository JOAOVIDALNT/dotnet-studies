
### Add
O método Add, assim como outros métodos que alteram a base de dados via EF, não alteram na primeira chamada, eles só sinalizam e preparam a base para uma alteração. A operação só é concluída ao executar o método 'SaveChanges'.

### SaveChanges
Não utilizaremos o SaveChanges individualmente nos métodos que alteram a base, pois podem existir problemas se salvarmos uma informação que depende de outra de um mesmo escopo e por ventura não pode ser salva.
A abordagem que utilizaremos, considera o escopo da requisição e só ao final das alterações devidas na base, salvamos as mudanças.

### UnitOfWork
Para esses casos, utilizaremos o UnitOfWork, e ai na regra de negócios faremos as alterações necessárias e só ao fim delas, convocaremos a unidade de trabalho para salvar as mudanças.

```csharp
namespace MyCookBook.Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork // Interface de MyCookBook.Domain
    {
        private readonly MyCookBookDbContext _context;

        public UnitOfWork(MyCookBookDbContext dbContext) => _context = dbContext;

        public async Task Commit() => await _context.SaveChangesAsync();
    }
}
```
Lembre-se que as interfaces(contratos) sempre estarão em 'Domain'.

Não esqueça de adicionar o 'UnitOfWork' ao 'DI Extension' 
```csharp
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        }
```

O fluxo do UseCase de registro de usuário ficaria assim:
```csharp
            Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);

            user.Password = _passwordEncrypter.Encrypt(request.Password);
           
            await _userWriteOnlyRepository.Add(user);
			// possíveis outras alterações na base
            await _uow.Commit(); // saveChangesAsync()
```
