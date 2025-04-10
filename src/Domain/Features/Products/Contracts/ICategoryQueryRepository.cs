using Domain.Features.Products.Entities;

namespace Domain.Features.Products.Contracts;

public interface ICategoryQueryRepository
{
    Task<List<Category>> GetAllAsync(CancellationToken ct);

    Task<Category> GetByIdAsync(int id, CancellationToken ct);
}