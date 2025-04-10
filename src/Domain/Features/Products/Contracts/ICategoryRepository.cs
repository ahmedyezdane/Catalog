using Domain.Features.Products.Entities;

namespace Domain.Features.Products.Contracts;

public interface ICategoryRepository
{
    Task<Category> AddAsync(Category category, CancellationToken ct);

    Task<List<Category>> LoadAllAsync(CancellationToken ct);

    Task<Category> LoadByIdAsync(int id, CancellationToken ct);

    void Update(Category category);
}
