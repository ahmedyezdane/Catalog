using ApplicationService.Products.Handlers.CategoryHandlers;
using AutoFixture;
using Domain.Features.Products.Commands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using Domain.Shadred.Exceptions;
using Domain.Shadred.Helpers;
using FluentAssertions;
using Moq;

namespace Catalog.UnitTests.HandlerTests.Products.CategoryHandlers;

public class UpdateCategoryHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock = new();

    private readonly UpdateCategoryHandler _handler;

    private readonly Fixture _fixture = new();

    public UpdateCategoryHandlerTests()
    {
        _handler = new UpdateCategoryHandler(_categoryRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Should_Update_Category()
    {
        // Arrange
        var existingCategory = Category.Create("Electronics", null);

        var command = _fixture.Build<UpdateCategoryCommand>()
                              .With(a => a.Id, existingCategory.Id)
                              .Create();

        _categoryRepositoryMock.Setup(r => r.LoadByIdAsync(command.Id, default))
                               .ReturnsAsync(existingCategory);

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert
        await action.Should().NotThrowAsync();

        _categoryRepositoryMock.Verify(r => r.LoadByIdAsync(command.Id, default), Times.Once);

        existingCategory.Name.Should().Be(command.Name);

        _unitOfWorkMock.Verify(u => u.CommitChangesAsync(default), Times.Once);
    }

    [Fact]
    public async Task Should_Throw_When_Category_Not_Found()
    {
        // Arrange
        var command = _fixture.Create<UpdateCategoryCommand>();

        // Act
        var action = async () => await _handler.Execute(command, default);

        // Assert
        string expectedErrorMessage = string.Format(DomainErrors.NotFoundEntity, nameof(Category));

        await action.Should()
                    .ThrowAsync<NotFoundEntityException>()
                    .WithMessage(expectedErrorMessage);

        _categoryRepositoryMock.Verify(r => r.LoadByIdAsync(command.Id, default), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitChangesAsync(default), Times.Never);
    }
}