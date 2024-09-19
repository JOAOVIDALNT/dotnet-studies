
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


### LIVRO
Para Livro, precisamos definir que o livro tem um único Autor que pode ter vários Livros.
Fazemos isso assim:
`Book -> Author`
```csharp
public void Configure(EntityTypeBuilder<Book> builder)
{
    builder
        .HasOne(b => b.Author)           // Cada Book tem um Author
        .WithMany(a => a.Books)          // Cada Author pode ter muitos Books
        .HasForeignKey(b => b.AuthorId); // A chave estrangeira no Book é AuthorId
}

```

Mas poderíamos também ter feito o mapeamento de `Author -> Book`, assim:
```csharp
public void Configure(EntityTypeBuilder<Author> builder) 
{
	builder
		.HasMany(a => a.Books)
		.WithOne(b => b.Author)
		.HasForeignKey(b => b.AuthorId);
}
```

Observe que:
- A primeira linha, define sobre a classe especificada e ela é bem descritiva. Lê-se
```text
Author -> Book: 
Um Autor .TemVarios virtual ICollection<Livro> Livros
Cada um .ComUm virtual Autor? Autor
.PossuiChaveEstrangeira virtual AutorId
```
- No caso dessa relação de `Autor -> Livros (um pra muitos)` as definições nas entidades ajudam a IDE a entender quais as relações, afinal, um autor tem uma lista de livros e o livro só tem um autor. Por isso o uso das propriedades de navegação é importante.

Faremos o mesmo para `Livros -> Gênero` e assim todas as relações já estarão definidas, apenas com o mapeamento de Usuário e Livro.

### CONCLUSÃO
Para as 4 entidades citadas, bastou apenas o mapeamento de duas delas, para apresentar a relação entre todas ao `EF CORE`.

Assim ficou o mapeamento de `Book` e `User`:
```csharp
public void Configure(EntityTypeBuilder<Book> builder)
{
    builder.ToTable("Books");
    builder.HasKey(x => x.Id);

    builder
        .HasOne(b => b.Author)
        .WithMany(a => a.Books)
        .HasForeignKey(b => b.AuthorId)
        .OnDelete(DeleteBehavior.Restrict);

    builder
        .HasOne(b => b.Genre)
        .WithMany(g => g.Books)
        .HasForeignKey(b => b.GenreId)
        .OnDelete(DeleteBehavior.Restrict);
}
```

```csharp
public void Configure(EntityTypeBuilder<User> builder)
{
    builder.ToTable("Users");
    builder.HasKey(x => x.Id);

    builder.HasMany(u => u.Books)
        .WithOne(b => b.User)
        .HasForeignKey(b => b.UserId)
        .OnDelete(DeleteBehavior.Restrict);

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