using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Products.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(Product product, CancellationToken ct)
    {
        await dbContext.Products.AddAsync(product, ct);
    }

    public async Task<Product?> LoadByIdAsync(int id, CancellationToken ct)
    {
        return await dbContext.Products.FirstOrDefaultAsync(c => c.Id == id, ct);
    }

    public async Task<PagedList<ProductDto>> GetAllAsync(BaseSearchDto inputDto, CancellationToken cancellationToken)
    {
        var query = dbContext.Products.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(inputDto.Filter))
        {
            query = query.Where(p =>
                p.Name.Contains(inputDto.Filter) ||
                p.Description.Contains(inputDto.Filter)
            );
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query.OrderBy(p => p.Name)
                                .Skip(inputDto.Skip).Take(inputDto.PageSize)
                                .Select(p => new ProductDto(
                                    p.Id,
                                    p.Name,
                                    p.Description,
                                    p.Price,
                                    p.AvailableStock,
                                    p.Slug,
                                    p.BrandId,
                                    p.CategoryId
                                ))
                                .ToListAsync(cancellationToken);

        return new PagedList<ProductDto>(items, totalCount, inputDto.PageNumber, inputDto.PageSize);
    }
}
