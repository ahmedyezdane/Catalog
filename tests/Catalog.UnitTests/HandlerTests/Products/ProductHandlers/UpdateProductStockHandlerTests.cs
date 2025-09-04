using ApplicationService.Products.Handlers.ProductHandlers;
using AutoFixture;
using Domain.Features.Products.Commands.ProductCommands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Features.Products.Exceptions;
using Domain.Shadred;
using Domain.Shadred.Exceptions;
using Domain.Shadred.Helpers;
using FluentAssertions;
using Moq;

namespace Catalog.UnitTests.HandlerTests.Products.ProductHandlers;

public class UpdateProductStockHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IProductRepository> _productRepositoryMock = new();

    private readonly UpdateProductStockHandler _handler;

    private readonly Fixture _fixture = new();

    public UpdateProductStockHandlerTests()
    {
        _handler = new UpdateProductStockHandler(_productRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Should_Update_Product_Stock()
    {
        // Arrange
        var product = Product.Create("Tablet", "Android tablet", _fixture.Create<int>(), _fixture.Create<int>(), 500, 20);

        var command = _fixture.Build<UpdateProductStockCommand>()
                              .With(c => c.Id, product.Id)
                              .With(c => c.NewQuantity, 15)
                              .Create();

        _productRepositoryMock.Setup(r => r.LoadByIdAsync(command.Id, default))
                              .ReturnsAsync(product);

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert
        await action.Should().NotThrowAsync();

        product.AvailableStock.Should().Be(command.NewQuantity);
        _unitOfWorkMock.Verify(u => u.CommitChangesAsync(default), Times.Once);
    }

    [Fact]
    public async Task Should_Throw_When_Product_Not_Found()
    {
        // Arrange
        var command = _fixture.Create<UpdateProductStockCommand>();

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert
        string expectedErrorMessage = string.Format(DomainErrors.NotFoundEntity, nameof(Product));

        await action.Should()
                    .ThrowAsync<NotFoundEntityException>()
                    .WithMessage(expectedErrorMessage);

        _unitOfWorkMock.Verify(u => u.CommitChangesAsync(default), Times.Never);
    }

    [Fact]
    public async Task Should_Throw_When_Stock_Is_Negative()
    {
        // Arrange
        var product = Product.Create("Tablet", "Android tablet", _fixture.Create<int>(), _fixture.Create<int>(), 500, 20);

        var command = _fixture.Build<UpdateProductStockCommand>()
                              .With(c => c.Id, product.Id)
                              .With(c => c.NewQuantity, -5)
                              .Create();

        _productRepositoryMock.Setup(r => r.LoadByIdAsync(command.Id, default))
                              .ReturnsAsync(product);

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert
        await action.Should().ThrowAsync<ProductStockNegativeQuantityException>();

        _unitOfWorkMock.Verify(u => u.CommitChangesAsync(default), Times.Never);
    }
}
