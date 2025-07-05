using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;
using Domain.Shadred;

namespace Infrastructure.Persistence.Products.Repositories;

internal class BrandQueryRepository : IBrandQueryRepository
{
    public Task<PagedList<BrandDto>> GetAllAsync(BaseSearchDto inputDto, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<BrandDto> GetByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
