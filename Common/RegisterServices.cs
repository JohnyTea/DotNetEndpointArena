using Microsoft.Extensions.DependencyInjection;

namespace Common;

public static class RegisterServices
{
    public static IServiceCollection RegisterCommonServices(this IServiceCollection services)
    {
        services.AddScoped<IHelloWorldService, HelloWorldService>();
        services.AddScoped<IToDoDbContext, InMemoryToDoDbContext>();
        services.AddScoped<ITodosService, TodosService>();
        return services;
    }
}
