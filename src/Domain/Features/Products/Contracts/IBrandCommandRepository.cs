using Domain.Features.Products.Entities;

namespace Domain.Features.Products.Contracts;

public interface IBrandCommandRepository
{
    Task<Brand> AddAsync(Brand brand, CancellationToken ct);

    Task<Brand> LoadByIdAsync(int id, CancellationToken ct);

    void Update(Brand brand);
}
