using Domain.Features.Products.Entities;

namespace Domain.Features.Products.Contracts;

public interface ICategoryCommandRepository
{
    Task AddAsync(Category category, CancellationToken ct);

    Task<Category> LoadByIdAsync(int id, CancellationToken ct);
}
