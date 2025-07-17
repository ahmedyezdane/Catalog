using Domain.Features.Products.Commands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred.CQRS;
using Domain.Shadred;
using Domain.Shadred.Exceptions;

namespace ApplicationService.Products.Handlers;

internal class UpdateBrandHandler : ICommandHandler<UpdateBrandCommand>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBrandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
    {
        _brandRepository = brandRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(UpdateBrandCommand command, CancellationToken cancellationToken)
    {
        var brand = await _brandRepository.LoadByIdAsync(command.Id,cancellationToken);
        if (brand is null)
            throw new NotFoundEntityException(typeof(Brand).Name);

        brand.Update(command.Name);
        
        await _unitOfWork.CommitChangesAsync(cancellationToken);
    }
}
