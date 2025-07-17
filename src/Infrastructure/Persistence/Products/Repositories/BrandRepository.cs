using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Products.Repositories;

internal class BrandRepository : IBrandRepository
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
        return dbContext.Brands.SingleOrDefaultAsync(b => b.Id == id, ct);
    }

    public Task<PagedList<BrandDto>> GetAllAsync(BaseSearchDto inputDto, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<BrandDto> GetByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
