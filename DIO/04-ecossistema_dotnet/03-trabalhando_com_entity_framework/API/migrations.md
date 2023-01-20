### Migrations

- Toda propriedade DbSet criará uma tabela no nosso banco de dados, toda criação de tabela, pedimos para o entity executar de maneira antecipada, essa maneira antecipada é o que chamamos de MIGRATIONS. Migrations é um mapeamento que o EF faz nas nossas classes, para poder transforma-las em tabelas.

> dotnet-ef migrations add CriacaoTabelaContato
faz a migração, cria a pasta Migrations no projeto com os comandos para se criar tabela
