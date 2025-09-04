using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Products.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext dbContext;

    public BrandRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(Brand brand, CancellationToken ct)
    {
        await dbContext.Brands.AddAsync(brand, ct);
    }

    public Task<Brand> LoadByIdAsync(int id, CancellationToken ct)
    {
        return dbContext.Brands.FirstOrDefaultAsync(b => b.Id == id, ct);
    }

    public async Task<PagedList<BrandDto>> GetAllAsync(BaseSearchDto inputDto, CancellationToken ct)
    {
        var query = dbContext.Brands.AsQueryable();

        if (!string.IsNullOrWhiteSpace(inputDto.Filter))
            query = query.Where(a => a.Name.Contains(inputDto.Filter));

        var total = await query.CountAsync();

        var result = await query.Select(a => new BrandDto(a.Name,a.WebsiteUrl))
                                .Skip(inputDto.Skip).Take(inputDto.PageSize)
                                .ToListAsync();

        return new PagedList<BrandDto>(result, total, inputDto.PageNumber, inputDto.PageSize);
    }
}
