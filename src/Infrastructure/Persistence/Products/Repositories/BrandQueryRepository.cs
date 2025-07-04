using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;

namespace Infrastructure.Persistence.Products.Repositories;

internal class BrandQueryRepository : IBrandQueryRepository
{
    public Task<List<BrandDto>> GetAllAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<BrandDto> GetByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
