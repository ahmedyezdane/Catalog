using Domain.Features.Products.DTOs;
using Domain.Features.Products.Entities;
using Domain.Shadred;

namespace Domain.Features.Products.Contracts;

public interface IBrandRepository
{
    Task AddAsync(Brand brand, CancellationToken ct);

    Task<Brand> LoadByIdAsync(int id, CancellationToken ct);

    Task<PagedList<BrandDto>> GetAllAsync(BaseSearchDto inputDto, CancellationToken ct);

    Task<BrandDto> GetByIdAsync(int id, CancellationToken ct);
}
