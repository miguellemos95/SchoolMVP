using Microsoft.Data.Sqlite;
using System.Data;

namespace Persistence.DatabaseConnection;

public class DbConnectionFactory : IDbConnectionFactory
{
    public IDbConnection CreateDbConnection(ConnectionStringOptions databaseOptions)
    {
        return databaseOptions switch
        {
            { DatabaseType: DatabaseType.Sqlite } => new SqliteConnection(databaseOptions.Connection),
            // Add support for other database types as needed
            _ => throw new NotSupportedException($"Database type {databaseOptions.Connection} is not supported."),
        };
    }
}