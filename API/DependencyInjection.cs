namespace SchoolAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddAPI(this IServiceCollection services) 
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        return services;
    }
}