using ApplicationService.Products.Handlers.BrandHandlers;
using AutoFixture;
using Domain.Features.Products.Commands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using Domain.Shadred.Exceptions;
using Domain.Shadred.Helpers;
using FluentAssertions;
using Moq;

namespace Catalog.UnitTests.HandlerTests.Products.BrandHandlers;

public class UpdateBrandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IBrandRepository> _brandRepositoryMock = new();

    private readonly UpdateBrandHandler _handler;

    private readonly Fixture _fixture = new();

    public UpdateBrandHandlerTests()
    {
        _handler = new UpdateBrandHandler(_brandRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Should_Update_Brand()
    {
        // Arrange
        const string brandWebsite = "https://apple.com";
        var existingBrand = Brand.Create("Apple", brandWebsite);

        var command = _fixture.Build<UpdateBrandCommand>().With(a => a.Id,existingBrand.Id).Create();

        _brandRepositoryMock.Setup(r => r.LoadByIdAsync(command.Id, default)).ReturnsAsync(existingBrand);

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert
        await action.Should().NotThrowAsync();

        _brandRepositoryMock.Verify(r => r.LoadByIdAsync(command.Id, default), Times.Once);

        existingBrand.Name.Should().Be(command.Name);
        existingBrand.WebsiteUrl.Should().Be(brandWebsite);

        _unitOfWorkMock.Verify(u => u.CommitChangesAsync(default), Times.Once);
    }

    [Fact]
    public async Task Should_Throw_When_Brand_Not_Found()
    {
        // Arrange
        var command = _fixture.Create<UpdateBrandCommand>();

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert

        string expectedErrorMessage = string.Format(DomainErrors.NotFoundEntity, nameof(Brand));

        await action.Should()
                    .ThrowAsync<NotFoundEntityException>()
                    .WithMessage(expectedErrorMessage);

        _brandRepositoryMock.Verify(r => r.LoadByIdAsync(command.Id, default), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitChangesAsync(default), Times.Never);
    }
}
