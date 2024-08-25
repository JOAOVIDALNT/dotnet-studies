
Considere um projeto de biblioteca, onde temos: `Usuários, Autores, Livros e Gênero`

### USUÁRIO
Um usuário vai ser vinculado à toda informação que inserir, com isso toda a informação vai ser vinculada à um usuário. Um usuário, tem listas de informações:
```csharp
public class User : EntityBase
{
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
```

Com isso, podemos concluir que a entidade usuário tem uma relação `one-to-many` com todas as 3 entidades. Ou seja, um usuário tem vários livros, mas um livro tem apenas um usuário.

Sendo assim, é assim que mapeamos as relações de usuário:
```csharp
public void Configure(EntityTypeBuilder<User> builder)
{
    builder.HasMany(u => u.Books) // Usuário tem vários Livros
        .WithOne(b => b.User) // Cada Livro tem um Usuário
        .HasForeignKey(b => b.UserId) // Com a chave estrangeira UserId
        .OnDelete(DeleteBehavior.Restrict); // Campo fica nulo

    builder.HasMany(u => u.Authors)
        .WithOne(a => a.User)
        .HasForeignKey(a => a.UserId)
        .OnDelete(DeleteBehavior.Restrict);

    builder.HasMany(u => u.Genres)
        .WithOne(g => g.User)
        .HasForeignKey(g => g.UserId)
        .OnDelete(DeleteBehavior.Restrict);
}
```

#### RELAÇÃO REVERSA
Considerando que nesse mapeamento de Usuário já dizemos pro `EF CORE` qual a relação com as 3 entidades, não precisamos declarar a relação nos mapeamentos das entidades em questão. Apenas se quisermos mais clareza no código.

#### PREFIXO `VIRTUAL`
O prefixo `virtual` nas propriedades que são referências, é uma boa prática que habilita o `lazy loading` oferecendo mais flexibilidade ao `EF CORE` pois permite que a entidade relacionada seja carregada de forma automática e sob demanda, ou seja, apenas quando você acessa a propriedade.