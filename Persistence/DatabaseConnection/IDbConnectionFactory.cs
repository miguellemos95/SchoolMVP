using System.Data;

namespace Persistence.DatabaseConnection;

public interface IDbConnectionFactory
{
    IDbConnection CreateDbConnection(ConnectionStringOptions databaseOptions);
}