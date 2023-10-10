using Microsoft.Extensions.DependencyInjection;

namespace StoreManager.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}