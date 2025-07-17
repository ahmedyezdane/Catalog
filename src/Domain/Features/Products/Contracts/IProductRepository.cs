using Domain.Features.Products.DTOs;
using Domain.Features.Products.Entities;

namespace Domain.Features.Products.Contracts;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken ct);

    Task<Product> LoadByIdAsync(int id, CancellationToken ct);

    Task<List<ProductDto>> GetAllAsync(int pageNo, int pageSize, string name, CancellationToken ct);

    Task<ProductDetailDto> GetBySlugAsync(string slug, CancellationToken ct);
}