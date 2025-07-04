using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;

namespace Infrastructure.Persistence.Products.Repositories;

internal class ProductQueryRepository : IProductQueryRepository
{
    public Task<List<ProductDto>> GetAllAsync(int pageNo, int pageSize, string name, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDetailDto> GetBySlugAsync(string slug, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
