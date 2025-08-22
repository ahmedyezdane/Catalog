using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;
using Domain.Features.Products.Entities;
using Domain.Shadred;
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

    public async Task<List<CategoryDto>> GetAllAsync(CancellationToken ct)
    {
        var query = dbContext.Categories.AsQueryable();

        return await query.Select(a => new CategoryDto(a.Id,a.Name, a.ParentId))
                          .ToListAsync();
    }
}
