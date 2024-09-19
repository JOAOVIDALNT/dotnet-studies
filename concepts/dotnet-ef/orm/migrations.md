
### `EF TOOLS`
O `Microsoft.EntityFrameworkCore.Tools` serve para gerenciar migrações pelo terminal integrado do `nuget package`, o `ef tools`, em projetos divididos,  não exige nenhuma configuração além para rodar. Apenas a instalação no projeto de origem e no de Infra.

### `EF DESIGN`
O `Microsoft.EntityFrameworkCore.Design` serve para gerenciar migrações pelo `dotnet CLI` e para os casos de projetos divididos, além da instalação no projeto original e de Infra, precisamos definir um  `Factory` para que o contexto fique acessível em **tempo de design**:
```csharp
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Your_Connection_String_Here");

        return new AppDbContext(optionsBuilder.Options);
    }
}
```