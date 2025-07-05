using Domain.Features.Products.Commands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using Domain.Shadred.CQRS;

namespace ApplicationService.Products.Handlers;

internal class CreateBrandHandler : ICommandHandler<CreateBrandCommand>
{
    private readonly IBrandCommandRepository _brandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBrandHandler(IBrandCommandRepository brandRepository, IUnitOfWork unitOfWork)
    {
        _brandRepository = brandRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(CreateBrandCommand command, CancellationToken cancellationToken)
    {
        var brand = Brand.Create(command.Name, command.LogoUrl);

        await _brandRepository.AddAsync(brand,cancellationToken);
        await _unitOfWork.CommitChangesAsync(cancellationToken);
    }
}
