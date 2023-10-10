using Microsoft.Extensions.DependencyInjection;

namespace StoreManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}