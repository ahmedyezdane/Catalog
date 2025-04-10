using Domain.Features.Products.DTOs;

namespace Domain.Features.Products.Contracts;

public interface IProductQueryRepository
{
    Task<List<ProductDto>> GetAllAsync (int pageNo, int pageSize, string name, CancellationToken ct);

    Task<ProductDetailDto> GetBySlugAsync (string slug, CancellationToken ct);
}