using Domain.Features.Products.Entities;

namespace Domain.Features.Products.Contracts;

public interface IBrandCommandRepository
{
    Task AddAsync(Brand brand, CancellationToken ct);

    Task<Brand> LoadByIdAsync(int id, CancellationToken ct);
}
