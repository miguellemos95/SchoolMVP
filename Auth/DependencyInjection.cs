using Microsoft.Extensions.DependencyInjection;

namespace Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        return services;
    }
}