using ApplicationService.Products.Handlers.BrandHandlers;
using AutoFixture;
using Domain.Features.Products.Commands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using FluentAssertions;
using Moq;

namespace Catalog.UnitTests.HandlerTests.Products.BrandHandlers;

public class CreateBrandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IBrandRepository> _brandRepositoryMock = new();

    private readonly CreateBrandHandler _handler;

    private readonly Fixture _fixture = new();

    public CreateBrandHandlerTests()
    {
        _handler = new CreateBrandHandler(_brandRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Should_Create_Brand()
    {
        // Arrange
        var command = _fixture.Create<CreateBrandCommand>();

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert
        await action.Should().NotThrowAsync();

        _brandRepositoryMock.Verify(
            a => a.AddAsync(It.Is<Brand>(a => a.Name == command.Name && a.WebsiteUrl == command.WebsiteUrl),default),
            Times.Once
        );

        _unitOfWorkMock.Verify(a => a.CommitChangesAsync(default),Times.Once);
    }
}
