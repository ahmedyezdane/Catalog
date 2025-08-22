using Domain.Features.Products.Commands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using Domain.Shadred.CQRS;
using Domain.Shadred.Exceptions;

namespace ApplicationService.Products.Handlers.CategoryHandlers;

public class UpdateCategoryHandler : ICommandHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.LoadByIdAsync(command.Id, cancellationToken);
        if (category is null)
            throw new NotFoundEntityException(typeof(Category).Name);

        category.Update(command.Name);

        await _unitOfWork.CommitChangesAsync(cancellationToken);
    }
}