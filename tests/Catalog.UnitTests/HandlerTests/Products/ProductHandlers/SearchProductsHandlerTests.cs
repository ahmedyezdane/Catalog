using ApplicationService.Products.Handlers.ProductHandlers;
using AutoFixture;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using FluentAssertions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Products.Repositories;

namespace Catalog.UnitTests.HandlerTests.Products.ProductHandlers;

[Collection("QueryHandlerCollection")]
public class SearchProductsHandlerTests
{
    private readonly ProductRepository _productRepository;
    private readonly BrandRepository _brandRepository;
    private readonly CategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly Fixture _fixture = new();

    private readonly SearchProductsHandler _handler;

    public SearchProductsHandlerTests(DatabaseFixture fixture)
    {
        _productRepository = new ProductRepository(fixture.Context);
        _brandRepository = new BrandRepository(fixture.Context);
        _categoryRepository = new CategoryRepository(fixture.Context);
        _unitOfWork = new UnitOfWork(fixture.Context);

        _handler = new(_productRepository);
    }

    [Fact]
    public async Task Should_Get_All_Products()
    {
        // Arrange
        var category = Category.Create(_fixture.Create<string>(),null);
        await _categoryRepository.AddAsync(category,default);

        var brand = Brand.Create(_fixture.Create<string>(), _fixture.Create<string>());
        await _brandRepository.AddAsync(brand, default);

        await _unitOfWork.CommitChangesAsync(default);

        const int productsCount = 10;
        var products = new List<Product>();

        for (int i = 0; i < productsCount; i++)
        {
            var product = Product.Create(_fixture.Create<string>(), _fixture.Create<string>(),
                                         brand.Id, category.Id,
                                         _fixture.Create<decimal>(), _fixture.Create<int>());
            products.Add(product);

            // sounds lame but i dont have any AddRange method in ProductRepository
            await _productRepository.AddAsync(product, default);
        }

        await _unitOfWork.CommitChangesAsync(default);

        var searchDto = new BaseSearchDto(1, productsCount * 2, string.Empty);

        // Act
        var result = await _handler.Fetch(searchDto, default);

        // Assert
        result.TotalItems.Should().Be(productsCount);
        result.CurrentPage.Should().Be(1);
        result.PageSize.Should().Be(productsCount * 2);

        foreach (var p in products)
            result.Data.Any(d => d.Name == p.Name && d.Description == p.Description).Should().BeTrue();
    }

    [Fact]
    public async Task Should_Get_Specific_Product()
    {
        // Arrange
        var category = Category.Create(_fixture.Create<string>(), null);
        await _categoryRepository.AddAsync(category, default);

        var brand = Brand.Create(_fixture.Create<string>(), _fixture.Create<string>());
        await _brandRepository.AddAsync(brand, default);

        await _unitOfWork.CommitChangesAsync(default);

        const int productsCount = 10;
        var products = new List<Product>();

        for (int i = 0; i < productsCount; i++)
        {
            var product = Product.Create(_fixture.Create<string>(), _fixture.Create<string>(),
                                         brand.Id, category.Id,
                                         _fixture.Create<decimal>(), _fixture.Create<int>());
            products.Add(product);

            // sounds lame but i dont have any AddRange method in ProductRepository
            await _productRepository.AddAsync(product, default);
        }

        await _unitOfWork.CommitChangesAsync(default);

        var targetProduct = products.OrderBy(a => Guid.NewGuid()).First();

        var searchDto = new BaseSearchDto(1, productsCount, targetProduct.Name);

        // Act
        var result = await _handler.Fetch(searchDto, default);

        // Assert
        result.TotalItems.Should().Be(1);
        result.Data.Count.Should().Be(1);

        result.Data.Any(d => d.Name == targetProduct.Name && d.Description == targetProduct.Description).Should().BeTrue();
    }
}