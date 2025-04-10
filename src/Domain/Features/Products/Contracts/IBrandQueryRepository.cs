using Domain.Features.Products.DTOs;

namespace Domain.Features.Products.Contracts;

public interface IBrandQueryRepository
{
    Task<List<BrandDto>> GetAllAsync(CancellationToken ct);

    Task<BrandDto> GetByIdAsync(int id, CancellationToken ct);
}
