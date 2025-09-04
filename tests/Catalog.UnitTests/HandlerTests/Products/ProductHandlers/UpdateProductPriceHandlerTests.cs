using ApplicationService.Products.Handlers.ProductHandlers;
using AutoFixture;
using Domain.Features.Products.Commands.ProductCommands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using Domain.Shadred.Exceptions;
using Domain.Shadred.Helpers;
using FluentAssertions;
using Moq;

namespace Catalog.UnitTests.HandlerTests.Products.ProductHandlers;

public class UpdateProductPriceHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IProductRepository> _productRepositoryMock = new();

    private readonly UpdateProductPriceHandler _handler;

    private readonly Fixture _fixture = new();

    public UpdateProductPriceHandlerTests()
    {
        _handler = new UpdateProductPriceHandler(_productRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Should_Update_Product_Price()
    {
        // Arrange
        var product = Product.Create("Laptop", "Gaming laptop", _fixture.Create<int>(), _fixture.Create<int>(), 1000, 5);

        var command = _fixture.Build<UpdateProductPriceCommand>()
                              .With(c => c.Id, product.Id)
                              .With(c => c.Price, 2000m)
                              .Create();

        _productRepositoryMock.Setup(r => r.LoadByIdAsync(command.Id, default))
                              .ReturnsAsync(product);

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert
        await action.Should().NotThrowAsync();

        product.Price.Should().Be(command.Price);
        _unitOfWorkMock.Verify(u => u.CommitChangesAsync(default), Times.Once);
    }

    [Fact]
    public async Task Should_Throw_When_Product_Not_Found()
    {
        // Arrange
        var command = _fixture.Create<UpdateProductPriceCommand>();

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert
        string expectedErrorMessage = string.Format(DomainErrors.NotFoundEntity, nameof(Product));

        await action.Should()
                    .ThrowAsync<NotFoundEntityException>()
                    .WithMessage(expectedErrorMessage);

        _unitOfWorkMock.Verify(u => u.CommitChangesAsync(default), Times.Never);
    }
}