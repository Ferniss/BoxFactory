using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver;

public static class DependencyResolver
{
    public static void RegisterApplicationLayer(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}