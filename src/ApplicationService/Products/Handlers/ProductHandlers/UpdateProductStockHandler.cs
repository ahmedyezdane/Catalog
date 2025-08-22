using Domain.Features.Products.Commands.ProductCommands;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.Entities;
using Domain.Shadred;
using Domain.Shadred.CQRS;
using Domain.Shadred.Exceptions;

namespace ApplicationService.Products.Handlers.ProductHandlers;

public class UpdateProductStockHandler : ICommandHandler<UpdateProductStockCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductStockHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(UpdateProductStockCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepository.LoadByIdAsync(command.Id, cancellationToken);
        if (product is null)
            throw new NotFoundEntityException(typeof(Product).Name);

        product.UpdateStock(command.NewQuantity);

        await _unitOfWork.CommitChangesAsync(cancellationToken);
    }
}
