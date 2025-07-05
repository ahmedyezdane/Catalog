using Domain.Features.Products.DTOs;
using Domain.Shadred;

namespace Domain.Features.Products.Contracts;

public interface IBrandQueryRepository
{
    Task<PagedList<BrandDto>> GetAllAsync(BaseSearchDto inputDto,CancellationToken ct);

    Task<BrandDto> GetByIdAsync(int id, CancellationToken ct);
}
