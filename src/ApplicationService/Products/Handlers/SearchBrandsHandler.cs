using System.Data;
using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;
using Domain.Shadred;
using Domain.Shadred.CQRS;

namespace ApplicationService.Products.Handlers;

public class SearchBrandsHandler : IQueryHandler<BaseSearchDto, PagedList<BrandDto>>
{
    private readonly IBrandRepository _brandRepository;

    public SearchBrandsHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<PagedList<BrandDto>> Fetch(BaseSearchDto inputDto, CancellationToken cancellationToken)
    {
        var result = await _brandRepository.GetAllAsync(inputDto,cancellationToken);

        return result;
    }
}
