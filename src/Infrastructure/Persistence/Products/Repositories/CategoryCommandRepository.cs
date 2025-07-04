using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;

namespace Infrastructure.Persistence.Products.Repositories;

internal class CategoryCommandRepository : ICategoryCommandRepository
{
    public Task AddAsync(Category category, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Category> LoadByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
