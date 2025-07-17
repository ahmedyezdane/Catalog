using Domain.Features.Products.Entities;

namespace Domain.Features.Products.Contracts;

public interface ICategoryRepository
{
    Task AddAsync(Category category, CancellationToken ct);

    Task<Category> LoadByIdAsync(int id, CancellationToken ct);

    Task<List<Category>> GetAllAsync(CancellationToken ct);

    Task<Category> GetByIdAsync(int id, CancellationToken ct);
}
