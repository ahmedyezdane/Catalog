using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Products.Repositories;

internal class BrandCommandRepository : IBrandCommandRepository
{
    private readonly ApplicationDbContext dbContext;

    public BrandCommandRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(Brand brand, CancellationToken ct)
    {
        await dbContext.Brands.AddAsync(brand, ct);
    }

    public Task<Brand> LoadByIdAsync(int id, CancellationToken ct)
    {
        return dbContext.Brands.SingleOrDefaultAsync(b => b.Id == id, ct);
    }
}
