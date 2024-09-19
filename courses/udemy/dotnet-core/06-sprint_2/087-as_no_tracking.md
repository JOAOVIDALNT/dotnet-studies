
Para iniciar as validações de login, vamos criar o método no `IUserReadOnlyRepository` que busca o usuário por email e senha:

```csharp
public Task<Entities.User?> GetByEmailAndPassword(string email, string password);
```

```csharp
public async Task<User?> GetByEmailAndPassword(string email, string password)
{
    return await _context.Users
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Active && x.Email.Equals(email) && x.Password.Equals(password));
}
```
Observe que
- Definimos como `AsNoTracking` pois sabemos que não atualizaremos a instância do Usuário, o que nos proporciona ganho de performance.
- Em `ReadOnly repositories` sempre que obtermos uma entidade, será `AsNoTracking`