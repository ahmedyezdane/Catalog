using Domain.Features.Products.Contracts;
using Domain.Shadred;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Products.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Infrastructure;

public static class ServiceCollector
{
    public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICategoryRepository, CategoryCommandRepository>();
        services.AddScoped<IProductRepository, ProductCommandRepository>();

        return services;
    }
}
