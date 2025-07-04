using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;

namespace Infrastructure.Persistence.Products.Repositories;

internal class CategoryQueryRepository : ICategoryQueryRepository
{
    public Task<List<Category>> GetAllAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
