##### Por que utilizar o fluent migrator ao invés de utilizar as migrations do EF?
A única justificativa plausível do Wellison foi a beleza do código kkkkkkkkkkk o restante é besteira.

#### Primeiro passo com migrations
Dentro do projeto de infra, adicionaremos dentro da pasta 'Migrations' a pasta 'Versions' para controlar as versões de migração.
Utilizaremos a máscara 'Version0000000' (Version + 7 casas) para versionar os arquivos de migração.

```csharp
using FluentMigrator;

namespace MyCookBook.Infrastructure.Migrations.Versions
{
    public class Version0000001 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            throw new NotImplementedException();
        }
    }
}
```
Observe que a classe deve estender de Migration, do FluentMigrator e implementar seus dois métodos Up e Down.

### UP
Utilizaremos a Up() para executar o código que queremos executar no banco de dados.

### DOWN
Realizar o processo inverso de UP.

Podemos utilizar o Down em casos onde precisamos desfazer alguma das migrações existentes.

### ForwardOnly
O time do FluentMigrator identificou que a maioria dos desenvolvedores sequer utilizava a função Down(), sempre deixando vazia ou não implementada e então adicionou uma nova interface, que implementa apenas a função Up(), denominada ForwardOnlyMigration.

```csharp
using FluentMigrator;

namespace MyCookBook.Infrastructure.Migrations.Versions
{
    public class Version0000001 : ForwardOnlyMigration
    {
        public override void Up()
        {
            throw new NotImplementedException();
        }
    }
}
```


### Versão
A especificação da versão não é feita pelo nome da classe (versione a nomemclatura como quiser).
mas sim, por uma anotação.

```csharp
using FluentMigrator;

namespace MyCookBook.Infrastructure.Migrations.Versions
{
    [Migration(1, "Create table to save the user's information")]
    public class Version0000001 : ForwardOnlyMigration
    {
        public override void Up()
        {
            throw new NotImplementedException();
        }
    }
}

```

#### Classe de extensão
Criaremos uma classe de extensão para abstrair as versões:
```csharp
namespace MyCookBook.Infrastructure.Migrations
{
    public abstract class DatabaseVersions
    {
        public const int TABLE_USER = 1;
    }
}
```
Assim, podemos anotar nossas classes de versão com algo do tipo:
```csharp
[Migration(1, "Create table to save the user's information")]
```


### Como a equipe deve utilizar as Migrations?
- Comunicação deve ser boa (scrum ajuda)
	- Se alguém tiver criado a mesma versão, saberão e ajustarão
	- Sprints são períodos curtos, então provavelmente não terão muitas migrações