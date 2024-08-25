
## PAGINAÇÃO COM SKIP E TAKE

Observe o exemplo de paginação na implementação de um repositório genérico:
```csharp
public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, int pageSize = 0, int pageNumber = 1)
{
    IQueryable<T> query = dbSet;

    if (filter != null)
        query = query.Where(filter);

    if (pageSize > 0)
        query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

    return await query.ToListAsync();
}
```

`pageSize` e `pageNumber` devem ser enviados a cada requisição.

Métodos `Skip` e `Take`:
- `SKIP` - Pula (ou ignora) um determinado número de itens no início da consulta
- `TAKE` - Após pular os itens necessários, este método seleciona o número de itens que devem ser retornados para a página atual.
A fórmula:
- A fórmula `pageSize * (pageNumber - 1)` calcula o número de itens a serem pulados, com base no número da página atual (`pageNumber`) e o tamanho da página (`pageSize`).

### Exemplo

Suponha que você tenha uma lista de 100 itens e deseja exibir 10 itens por página:

- Para a **primeira página** (`pageNumber = 1`):
    
    - `Skip(pageSize * (pageNumber - 1))` => `Skip(10 * (1 - 1))` => `Skip(0)`
    - `Take(pageSize)` => `Take(10)`
    
    Resulta nos itens de 1 a 10.
    
- Para a **segunda página** (`pageNumber = 2`):
    
    - `Skip(pageSize * (pageNumber - 1))` => `Skip(10 * (2 - 1))` => `Skip(10)`
    - `Take(pageSize)` => `Take(10)`
    
    Resulta nos itens de 11 a 20.


## OUTROS MÉTODOS DE PAGINAÇÃO
### 1. **Paginação por Cursor (ou Continuation Token)**

**Descrição**: Em vez de usar `pageNumber` e `pageSize`, você usa um cursor ou um token de continuação para marcar a posição na lista de dados. Isso é útil para conjuntos de dados que mudam frequentemente.

**Como Funciona**:

- A resposta inclui um cursor (por exemplo, o ID do último item retornado).
- Para a próxima página, a requisição inclui esse cursor para retornar os itens subsequentes.

**Exemplo**:
```csharp
public IQueryable<T> GetPagedDataByCursor<T>(IQueryable<T> query, int pageSize, string lastItemId)
{
    var filteredQuery = string.IsNullOrEmpty(lastItemId) 
        ? query 
        : query.Where(item => item.Id.CompareTo(lastItemId) > 0);

    return filteredQuery.Take(pageSize);
}
```
**Vantagens**:

- Melhor para dados que mudam frequentemente, pois evita problemas com dados ausentes ou duplicados devido a inserções ou exclusões.

**Desvantagens**:

- Mais complexo para implementar e gerenciar do que a paginação tradicional por índice.

### 2. **Paginação Baseada em Índice**

**Descrição**: Similar à paginação por `Skip` e `Take`, mas usa índices específicos em vez de calcular offsets. Isso pode ser útil para consultas que possuem um índice específico para paginação.

**Como Funciona**:

- Baseia-se em índices pré-definidos (por exemplo, IDs de itens) para determinar quais itens retornar.

**Exemplo**:
```csharp
public IQueryable<T> GetPagedDataByIndex<T>(IQueryable<T> query, int startIndex, int pageSize)
{
    return query.Skip(startIndex).Take(pageSize);
}
```

**Vantagens**:

- Simples de implementar e entender.

**Desvantagens**:

- Pode ser menos eficiente com grandes conjuntos de dados, especialmente se a consulta for lenta para saltar grandes quantidades de dados.


### 3. **Paginação Baseada em Metadata**

**Descrição**: Usada em APIs que precisam retornar metadados junto com os dados paginados, como contagem total de itens e dados da página atual.

**Como Funciona**:

- Retorna metadados como o número total de itens, a página atual, e o total de páginas, além dos dados da página.

**Exemplo**:
```csharp
public class PagedResult<T>
{
    public int TotalCount { get; set; }
    public IEnumerable<T> Items { get; set; }
}

public PagedResult<T> GetPagedData<T>(IQueryable<T> query, int pageNumber, int pageSize)
{
    var totalCount = query.Count();
    var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

    return new PagedResult<T>
    {
        TotalCount = totalCount,
        Items = items
    };
}
```

**Vantagens**:

- Fornece informações completas sobre a paginação, o que pode ser útil para interfaces de usuário.

**Desvantagens**:

- Pode ser mais complexo de implementar e pode exigir cálculos adicionais.

**Exemplo de fluxo**

Requisição:
```http
GET /api/items?pageNumber=2&pageSize=10
```
Resposta:
```json
{
    "totalCount": 100,
    "pageSize": 10,
    "currentPage": 2,
    "totalPages": 10,
    "items": [
        // Dados da página 2
    ]
}
```

### PAGINAÇÃO NO REPOSITÓRIO OU NO SERVIÇO
Independente do método de paginação, podemos escolher se queremos fazer no repositório ou no serviço.
#### Serviço
Fazer no serviço, torna o código menos acoplado, mas pode causar mais `boilerplate`.

Exemplo de consulta no repositório caso escolha tratar a paginação no serviço:
```csharp
public IQueryable<T> GetQuery(Expression<Func<T, bool>>? filter)
{
    var query = dbSet.AsQueryable();

    if (filter != null)
        query = query.Where(filter);

    return query;
}
```

#### Repositório
Fazer no repositório diminui a repetição de código, mas deixa o aplicação menos flexível para diferentes tratativas:

Exemplo de tratativa direta no repositório genérico
```csharp
public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, int pageSize = 0, int pageNumber = 1)
{
    IQueryable<T> query = dbSet;

    if (filter != null)
        query = query.Where(filter);

    if (pageSize > 0)
        query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

    return await query.ToListAsync();
}
```