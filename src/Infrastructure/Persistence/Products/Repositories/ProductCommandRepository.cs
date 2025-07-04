using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;

namespace Infrastructure.Persistence.Products.Repositories;

internal class ProductCommandRepository : IProductCommandRepository
{
    public Task AddAsync(Product product, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Product> LoadByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
