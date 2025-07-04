using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;

namespace Infrastructure.Persistence.Products.Repositories;

internal class BrandCommandRepository : IBrandCommandRepository
{
    public Task AddAsync(Brand brand, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Brand> LoadByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
