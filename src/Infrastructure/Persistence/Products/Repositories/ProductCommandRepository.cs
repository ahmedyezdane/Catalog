using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;
using Domain.Features.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Products.Repositories;

internal class ProductCommandRepository : IProductRepository
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

    public Task<List<ProductDto>> GetAllAsync(int pageNo, int pageSize, string name, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDetailDto> GetBySlugAsync(string slug, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
