using Domain.Features.Products.DTOs;
using Domain.Features.Products.Entities;
using Domain.Shadred;

namespace Domain.Features.Products.Contracts;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken ct);

    Task<Product?> LoadByIdAsync(int id, CancellationToken ct);

    Task<PagedList<ProductDto>> GetAllAsync(BaseSearchDto inputDto, CancellationToken ct);
}