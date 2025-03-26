using Domain.Products.Entities;

namespace Domain.Products.Contracts;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product,CancellationToken ct);

    Task<List<Product>> LoadAllAsync(int pageNo,int pageSize,string name,CancellationToken ct);

    Task<Product> LoadByIdAsync(int id, CancellationToken ct);

    Task<Product> LoadBySlugAsync(int id, CancellationToken ct);

    void Update(Product product);
}
