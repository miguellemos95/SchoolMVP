using System.Data;

namespace Persistence.DatabaseConnection;

public interface IDbConnectionManager
{
    void EnsureConnectionOpen(IDbConnection connection);
}