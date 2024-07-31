
Utilizaremos o DAPPER como uma outra opção de ORM e a principio criaremos as migrations iniciais:

```csharp
using Dapper;
using Microsoft.Data.SqlClient;
using MyCookBook.Domain.Enums;

namespace MyCookBook.Infrastructure.Migrations
{
    public static class DatabaseMigration
    {
        public static void Migrate(DatabaseType databaseType, string connectionString)
        {
            if (databaseType == DatabaseType.Conn1)
                EnsureDatabaseCreated_SqlServer(connectionString);
        }

        private static void EnsureDatabaseCreated_SqlServer(string connectionString)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var dbName = connectionStringBuilder.InitialCatalog;

            connectionStringBuilder.Remove("Database");
// removendo o database do connection pois não sabemos se existe ainda
            using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);

            var records = dbConnection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);

            if (!records.Any())
                dbConnection.Execute($"CREATE DATABASE {dbName}");
        }
    }
}
```