using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Products.Repositories;

internal class CategoryCommandRepository : ICategoryRepository
{
    private readonly ApplicationDbContext dbContext;

    public CategoryCommandRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(Category category, CancellationToken ct)
    {
        await dbContext.Categories.AddAsync(category, ct);
    }

    public async Task<Category> LoadByIdAsync(int id, CancellationToken ct)
    {
        return await dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id, ct);
    }

    public Task<List<Category>> GetAllAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
