using System.Data;
using ApplicationService.Products.Handlers.BrandHandlers;
using ApplicationService.Products.Handlers.CategoryHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationService;

public static class ServiceCollector
{
    public static IServiceCollection RegisterHandlers(this IServiceCollection services)
    {
        #region Brand

        services.AddScoped<CreateBrandHandler>();
        services.AddScoped<SearchBrandsHandler>();
        services.AddScoped<UpdateBrandHandler>();

        #endregion

        #region Category

        services.AddScoped<CreateCategoryHandler>();
        services.AddScoped<SearchCategoriesHandler>();
        services.AddScoped<UpdateCategoryHandler>();

        #endregion

        return services;
    }
}
