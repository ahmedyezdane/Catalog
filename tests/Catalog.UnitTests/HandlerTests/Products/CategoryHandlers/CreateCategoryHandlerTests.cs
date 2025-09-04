using ApplicationService.Products.Handlers.CategoryHandlers;
using AutoFixture;
using Domain.Features.Products.Commands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using FluentAssertions;
using Moq;

namespace Catalog.UnitTests.HandlerTests.Products.CategoryHandlers;

public class CreateCategoryHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock = new();

    private readonly CreateCategoryHandler _handler;

    private readonly Fixture _fixture = new();

    public CreateCategoryHandlerTests()
    {
        _handler = new CreateCategoryHandler(_categoryRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Should_Create_Category()
    {
        // Arrange
        var command = _fixture.Create<CreateCategoryCommand>();

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert
        await action.Should().NotThrowAsync();

        _categoryRepositoryMock.Verify(
            a => a.AddAsync(It.Is<Category>(a => a.Name == command.Name && a.ParentId == command.ParentId), default),
            Times.Once
        );

        _unitOfWorkMock.Verify(a => a.CommitChangesAsync(default), Times.Once);
    }
}