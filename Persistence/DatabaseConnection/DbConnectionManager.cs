using System.Data;

namespace Persistence.DatabaseConnection;

public class DbConnectionManager : IDbConnectionManager
{
    public void EnsureConnectionOpen(IDbConnection connection)
    {
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }
    }
}