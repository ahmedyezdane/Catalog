using ApplicationService.Products.Handlers.ProductHandlers;
using AutoFixture;
using Domain.Features.Products.Commands.ProductCommands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using FluentAssertions;
using Moq;

namespace Catalog.UnitTests.HandlerTests.Products.ProductHandlers;

public class CreateProductHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IProductRepository> _productRepositoryMock = new();

    private readonly CreateProductHandler _handler;

    private readonly Fixture _fixture = new();

    public CreateProductHandlerTests()
    {
        _handler = new CreateProductHandler(_productRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Should_Create_Product()
    {
        // Arrange
        var command = _fixture.Create<CreateProductCommand>();

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert
        await action.Should().NotThrowAsync();

        _productRepositoryMock.Verify(
            r => r.AddAsync(It.Is<Product>(p =>
                p.Name == command.Name &&
                p.Description == command.Description &&
                p.BrandId == command.BrandId &&
                p.CategoryId == command.CategoryId &&
                p.Price == command.Price &&
                p.AvailableStock == command.AvailableStock
            ), default),
            Times.Once);

        _unitOfWorkMock.Verify(u => u.CommitChangesAsync(default), Times.Once);
    }
}
