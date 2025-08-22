using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;
using Domain.Shadred;
using Domain.Shadred.CQRS;

namespace ApplicationService.Products.Handlers.ProductHandlers;

public class SearchProductsHandler : IQueryHandler<BaseSearchDto, PagedList<ProductDto>>
{
    private readonly IProductRepository _productRepository;

    public SearchProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PagedList<ProductDto>> Fetch(BaseSearchDto inputDto, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAllAsync(inputDto, cancellationToken);
        return result;
    }
}