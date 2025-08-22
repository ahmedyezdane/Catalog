using Domain.Features.Products.Commands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using Domain.Shadred.CQRS;

namespace ApplicationService.Products.Handlers.CategoryHandlers;

public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = Category.Create(command.Name, command.ParentId);

        await _categoryRepository.AddAsync(category, cancellationToken);
        await _unitOfWork.CommitChangesAsync(cancellationToken);
    }
}
