using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using Persistence.DatabaseConnection;
using Application.Common.Contracts;
using Persistence.Common;
using Application.SchoolFeatures.Contracts;
using Persistence.SchoolPersistence;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        DatabaseConnectionBuilder(services);

        AddRepositoryServices(services);

        return services;
    }

    private static void AddRepositoryServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
    }

    private static void DatabaseConnectionBuilder(IServiceCollection services)
    {
        services.ConfigureOptions<ConnectionStringSetup>();

        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
        services.AddSingleton<IDbConnectionManager, DbConnectionManager>();

        services.AddDbContext<CoreContext>((serviceProvider, dbContextOptionsBuilder) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<ConnectionStringOptions>>()!.Value;

            var dbConnectionFactory = serviceProvider.GetRequiredService<IDbConnectionFactory>();
            var dbConnectionManager = serviceProvider.GetRequiredService<IDbConnectionManager>();

            IDbConnection dbConnection = dbConnectionFactory.CreateDbConnection(databaseOptions);
            dbConnectionManager.EnsureConnectionOpen(dbConnection);

            dbContextOptionsBuilder.UseSqlite(databaseOptions.Connection);
        });
    }
}