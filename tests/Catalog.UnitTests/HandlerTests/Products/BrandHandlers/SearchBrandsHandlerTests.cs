using ApplicationService.Products.Handlers.BrandHandlers;
using AutoFixture;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using FluentAssertions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Products.Repositories;

namespace Catalog.UnitTests.HandlerTests.Products.BrandHandlers;

[Collection("QueryHandlerCollection")]
public class SearchBrandsHandlerTests
{
    private readonly BrandRepository _brandRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly Fixture _fixture = new();

    private readonly SearchBrandsHandler _handler;

    public SearchBrandsHandlerTests(DatabaseFixture fixture)
    {
        _brandRepository = new BrandRepository(fixture.Context);
        _unitOfWork = new UnitOfWork(fixture.Context);

        _handler = new(_brandRepository);
    }

    [Fact]
    public async Task Should_Get_All_Brands()
    {
        // Arrange

        const int brandsCount = 10;

        var brands = new List<Brand>();

        for (var i = 0; i < brandsCount; i++)
        {
            var brand = Brand.Create(_fixture.Create<string>(), _fixture.Create<string>());
            brands.Add(brand);

            // sounds lame but i dont have any AddRange method in BrandRepository
            await _brandRepository.AddAsync(brand, default);
        }

        await _unitOfWork.CommitChangesAsync(default);

        var searchDto = new BaseSearchDto(1, brandsCount * 2, string.Empty);

        // Act
        var result = await _handler.Fetch(searchDto, default);

        // Assert
        result.TotalItems = brandsCount;
        result.CurrentPage = 1;
        result.PageSize = brandsCount * 2;

        foreach (var b in brands)
            result.Data.Any(a => a.Name == b.Name && a.WebsiteUrl == b.WebsiteUrl).Should().Be(true);
    }

    [Fact]
    public async Task Should_Get_Specific_Brand()
    {
        // Arrange

        const int brandsCount = 10;

        var brands = new List<Brand>();

        for (var i = 0; i < brandsCount; i++)
        {
            var brand = Brand.Create(_fixture.Create<string>(), _fixture.Create<string>());
            brands.Add(brand);

            // sounds lame but i dont have any AddRange method in BrandRepository
            await _brandRepository.AddAsync(brand, default);
        }

        await _unitOfWork.CommitChangesAsync(default);

        var targetBrand = brands.OrderBy(a => Guid.NewGuid()).First();

        var searchDto = new BaseSearchDto(1, brandsCount, targetBrand.Name);

        // Act
        var result = await _handler.Fetch(searchDto, default);

        // Assert
        result.TotalItems = 1;
        
        result.Data.Count.Should().Be(1);

        result.Data.Any(a => a.Name == targetBrand.Name && a.WebsiteUrl == targetBrand.WebsiteUrl);
    }
}
