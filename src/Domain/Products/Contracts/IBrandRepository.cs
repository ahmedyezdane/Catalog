using Domain.Products.Entities;

namespace Domain.Products.Contracts;

public interface IBrandRepository
{
    Task<Brand> AddAsync(Brand brand, CancellationToken ct);

    Task<List<Brand>> LoadAllAsync(int pageNo, int pageSize, string name, CancellationToken ct);

    Task<Brand> LoadByIdAsync(int id, CancellationToken ct);

    void Update(Brand brand);
}