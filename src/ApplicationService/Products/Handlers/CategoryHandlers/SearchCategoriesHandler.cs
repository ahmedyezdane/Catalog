using Domain.Features.Products.Contracts;
using Domain.Features.Products.DTOs;
using Domain.Shadred;
using Domain.Shadred.CQRS;

namespace ApplicationService.Products.Handlers.CategoryHandlers;

public class SearchCategoriesHandler : IQueryHandler<List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public SearchCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> Fetch(CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.GetAllAsync(cancellationToken);
        return result;
    }
}