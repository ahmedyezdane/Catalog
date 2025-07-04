using Domain.Features.Products.Entities;

namespace Domain.Features.Products.Contracts;

public interface IProductCommandRepository
{
    Task AddAsync(Product product, CancellationToken ct);

    Task<Product> LoadByIdAsync(int id, CancellationToken ct);
}