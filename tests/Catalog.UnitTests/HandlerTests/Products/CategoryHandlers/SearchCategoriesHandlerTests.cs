using ApplicationService.Products.Handlers.CategoryHandlers;
using AutoFixture;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using FluentAssertions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Products.Repositories;

namespace Catalog.UnitTests.HandlerTests.Products.CategoryHandlers;

[Collection("QueryHandlerCollection")]
public class SearchCategoriesHandlerTests
{
    private readonly CategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly Fixture _fixture = new();

    private readonly SearchCategoriesHandler _handler;

    public SearchCategoriesHandlerTests(DatabaseFixture fixture)
    {
        _categoryRepository = new CategoryRepository(fixture.Context);
        _unitOfWork = new UnitOfWork(fixture.Context);

        _handler = new(_categoryRepository);
    }

    [Fact]
    public async Task Should_Get_All_Categories()
    {
        // Arrange
        const int categoriesCount = 10;

        var categories = new List<Category>();

        for (var i = 0; i < categoriesCount; i++)
        {
            var category = Category.Create(_fixture.Create<string>(), null);
            categories.Add(category);

            await _categoryRepository.AddAsync(category, default);
        }

        await _unitOfWork.CommitChangesAsync(default);

        // Act
        var result = await _handler.Fetch(default);

        // Assert
        result.Count.Should().Be(categoriesCount);

        foreach (var c in categories)
            result.Any(a => a.Name == c.Name).Should().Be(true);
    }
}