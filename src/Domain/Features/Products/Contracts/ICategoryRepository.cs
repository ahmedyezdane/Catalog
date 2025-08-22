using Domain.Features.Products.DTOs;
using Domain.Features.Products.Entities;
using Domain.Shadred;

namespace Domain.Features.Products.Contracts;

public interface ICategoryRepository
{
    Task AddAsync(Category category, CancellationToken ct);

    Task<Category> LoadByIdAsync(int id, CancellationToken ct);

    Task<List<CategoryDto>> GetAllAsync(CancellationToken ct);
}
