
A função up de migrações vai abrigar instruções explícitas para a base de dados, confira o exemplo:
```csharp
namespace MyCookBook.Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_USER, "Create table to save the user's information")]
    public class Version0000001 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Password").AsString(2000).NotNullable();
        }
    }
}
```


### Abstraindo dados constantes
Assim como temos nossa EntityBase, que todas as classes herdarão:
```csharp
    public class EntityBase
    {
        public long Id { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
```

Podemos criar a nossa VersionBase, com métodos que nossas classes de versão podem herdar e que já possuem esses dados constantes:
```csharp
using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace MyCookBook.Infrastructure.Migrations.Versions
{
    public abstract class VersionBase : ForwardOnlyMigration
    {
        protected ICreateTableColumnOptionOrWithColumnSyntax CreateTable(string table)
        {
            return Create.Table(table)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable();
        }
    }
}
```
Observe que:
- A classe VersionBase é abstrata e não precisa implementar ForwarOnlyMigration, ou seja, ela assume diretamente que vai herdar as mesmas definições
- Para definir o tipo de retorno do método CreateTable, basta conferir a tipagem nos métodos ou seguir a #DicaTipoDesconhecido.
- O método CreateTable é protected para que apenas classes que estendem de VersionBase possa utiliza-lo.

Assim ficará o novo arquivo de Versão:
```csharp
namespace MyCookBook.Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_USER, "Create table to save the user's information")]
    public class Version0000001 : VersionBase
    {
        public override void Up()
        {
            CreateTable("Users")
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Password").AsString(2000).NotNullable();
        }
    }
}
```
Estendendo de VersionBase e não precisando definir os atributos fixos em Create.Table, ao invés disso, utilizamos o CreateTable de VersionBase, e definimos os demais atributos.


### DicaTipoDesconhecido
Ao abstrair o método CreateTable para simplificar a criação de tabelas, era necessário retornar o tipo certo para conseguir manipular os recursos do FluentMigrator, uma dica interessante para descobrir um tipo desconhecido é retornar algo com a função desejada em um void. 
Assim, em show potential fixes, o visual studio vai sugerir o tipo.

