using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Persistence.DatabaseConnection;

public class ConnectionStringSetup : IConfigureOptions<ConnectionStringOptions>
{
    private const string SectionName = "ConnectionString";
    private readonly IConfiguration _configuration;

    public ConnectionStringSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ConnectionStringOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}