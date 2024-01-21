namespace Persistence.DatabaseConnection;

public class ConnectionStringOptions
{
    public string Connection { get; init; } = string.Empty;
    public DatabaseType DatabaseType { get; init; }
}