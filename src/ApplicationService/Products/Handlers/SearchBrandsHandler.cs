using System.Data;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;
using Domain.Shadred;
using Domain.Shadred.CQRS;

namespace ApplicationService.Products.Handlers;

public class SearchBrandsHandler : IQueryHandler<BaseSearchDto, PagedList<BrandDto>>
{
    private readonly IBrandQueryRepository _brandQueryRepository;

    public SearchBrandsHandler(IBrandQueryRepository brandQueryRepository)
    {
        _brandQueryRepository = brandQueryRepository;
    }

    public Task<PagedList<BrandDto>> Fetch(BaseSearchDto inputDto, CancellationToken cancellationToken)
    {
        var result = _brandQueryRepository.GetAllAsync(inputDto,cancellationToken);

        return result;
    }
}
