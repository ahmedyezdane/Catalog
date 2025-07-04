using Domain.Features.Products.Contracts;
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
        services.AddScoped<IDbConnection>(_ => new SqlConnection(connectionString));
        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
        services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();
        services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
        services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
        services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
        services.AddScoped<IProductQueryRepository, ProductQueryRepository>();

        return services;
    }
}
