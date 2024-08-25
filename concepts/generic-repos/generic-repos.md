
### CONCEITO
Para lidar com repositórios, podemos utilizar uma abordagem genérica, para evitar `boilerplate` na definição de vários métodos para diferentes entidades, e ainda assim podemos tratar das entidades com métodos específicos dentro da sua própria interface de repositório.

### IMPLEMENTAÇÃO

#### GENÉRICO
##### INTERFACE GENÉRICA
```csharp
public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, int pageSize = 0, int pageNumber = 1);
    Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
```

##### REPOSITÓRIO GENÉRICO
```csharp
public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(AppDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
    }

    public async Task CreateAsync(T entity) => await dbSet.AddAsync(entity);
    public void Update(T entity) => dbSet.Update(entity);
    public void Delete(T entity) => dbSet.Remove(entity);
    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, int pageSize = 0, int pageNumber = 1)
    {
        IQueryable<T> query = dbSet;

        if (filter != null)
            query = query.Where(filter);

        if (pageSize > 0)
            query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

        return await query.ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
    {
        IQueryable<T> query = dbSet;

        if (!tracked)
            query = query.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        return await query.FirstOrDefaultAsync();
    }
}
```


#### ESPECÍFICO

##### INTERFACE ESPECÍFICA
```csharp
public interface IBookRepository : IRepository<Book>
{
}
```
Observe que:
- Não há nenhum contrato específico, ainda assim utilizamos a interface para operações com o tipo `Book` e caso seja necessário, podemos sobrescrever ações ou criar novas ações específicas.

##### REPOSITÓRIO ESPECÍFICO
```csharp
public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(AppDbContext db) : base(db) { };
}
```
Observe que:
- Nosso repositório herda da instância do repositório genérico considerando que o nosso tipo foi especificado.
- Há uma maneira mais simples de gerar esse construtor através do `Primary Constructor`: 
```csharp
public class BookRepository(AppDbContext db) : Repository<Book>(db), IBookRepository
{
}
```
- Observe o `base(db)` agora aplicado diretamente na referência `Repository<Book>(db)`
- Com o `Primary Constructor` deve ser possível acessar a instância de `_db` de `Repository<T>` assim possibilitando a utilização da instância nas nossas implementações específicas

#### PROTECTED `_db`
Para que as implementações específicas consigam acessar os dados, é importante de a instância do contexto em `Repository<T>` não seja privada e sim protegida:
```csharp
protected readonly AppDbContext _db;
```
