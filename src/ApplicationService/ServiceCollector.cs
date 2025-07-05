using System.Data;
using ApplicationService.Products.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationService;

public static class ServiceCollector
{
    public static IServiceCollection RegisterHandlers(this IServiceCollection services)
    {
        #region Products

        services.AddScoped<CreateBrandHandler>();
        services.AddScoped<SearchBrandsHandler>();
        services.AddScoped<UpdateBrandHandler>();

        #endregion

        return services;
    }
}
