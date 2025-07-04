using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Products.Repositories;

internal class ProductCommandRepository : IProductCommandRepository
{
    private readonly ApplicationDbContext dbContext;

    public ProductCommandRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(Product product, CancellationToken ct)
    {
        await dbContext.Products.AddAsync(product, ct);
    }

    public async Task<Product> LoadByIdAsync(int id, CancellationToken ct)
    {
        return await dbContext.Products.SingleOrDefaultAsync(c => c.Id == id, ct);
    }
}
