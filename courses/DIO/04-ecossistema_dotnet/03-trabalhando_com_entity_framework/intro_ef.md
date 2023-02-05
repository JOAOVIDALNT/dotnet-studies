### Entity Framework

- O EF é um framework ORM(Object-Relational Mapping) criado para facilitar a integração com o banco de dados, mapeando tabelas e gerando comandos SQL de forma automática.

> GERA QUERY DE MANEIRA DINÂMICA DIRETO DO .NET

#### CRUD

- CREATE (Insert)

- READ (Select)

- UPDATE (Update)

- DELETE (Delete)

> SÃO AS OPERAÇÕES MAIS COMUNS NA MANIPULAÇÃO DE UM BANCO DE DADOS


#### Instalando EF 

> dotnet tool install --global dotnet-ef
Você pode invocar a ferramenta usando o comando a seguir: dotnet-ef
A ferramenta 'dotnet-ef' (versão '7.0.2') foi instalada com êxito.
- é instalado de maneira global na máquina, por isso é necessário instalar uma única vez


> dotnet add package Microsoft.EntityFrameworkCore.Design
- é o pacote do EF para utilizar no seu projeto, precisa ser instalado individualmente em cada projeto

> dotnet add package Microsoft.EntityFrameworkCore.SqlServer
- pacote do EF para integração com SQL Server a nível de projeto