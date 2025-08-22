using ApplicationService.Products.Handlers.BrandHandlers;
using ApplicationService.Products.Handlers.CategoryHandlers;
using Domain.Features.Products.Commands;
using Domain.Features.Products.DTOs;
using Domain.Shadred;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    #region Brand

    [HttpPost("create-brand")]
    public async Task<IActionResult> CreateBrand(
        [FromServices] CreateBrandHandler handler,
        [FromBody] CreateBrandCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            await handler.Execute(command, cancellationToken);
            return Ok();
        }
        catch (Exception)
        {
            // TODO: Log
            throw;
        }
    }

    [HttpPut("update-brand")]
    public async Task<IActionResult> UpdateBrand(
    [FromServices] UpdateBrandHandler handler,
    [FromBody] UpdateBrandCommand command,
    CancellationToken cancellationToken)
    {
        try
        {
            await handler.Execute(command, cancellationToken);
            return Ok();
        }
        catch (Exception)
        {
            // TODO: Log
            throw;
        }
    }

    [HttpGet("search-brand")]
    [ProducesResponseType(typeof(PagedList<BrandDto>), 200)]
    public async Task<IActionResult> SearchBrand(
        [FromServices] SearchBrandsHandler handler,
        int pageNumber, int pageSize, string? filter,
        CancellationToken cancellationToken)
    {
        try
        {
            var dto = new BaseSearchDto(pageNumber, pageSize,filter);
            return Ok(await handler.Fetch(dto, cancellationToken));
        }
        catch (Exception)
        {
            // TODO: Log
            throw;
        }
    }

    #endregion Brand

    #region Category

    [HttpPost("create-category")]
    public async Task<IActionResult> CreateCategory(
        [FromServices] CreateCategoryHandler handler,
        [FromBody] CreateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            await handler.Execute(command, cancellationToken);
            return Ok();
        }
        catch (Exception)
        {
            // TODO: Log
            throw;
        }
    }

    [HttpPut("update-category")]
    public async Task<IActionResult> UpdateCategory(
        [FromServices] UpdateCategoryHandler handler,
        [FromBody] UpdateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            await handler.Execute(command, cancellationToken);
            return Ok();
        }
        catch (Exception)
        {
            // TODO: Log
            throw;
        }
    }

    [HttpGet("search-category")]
    [ProducesResponseType(typeof(List<CategoryDto>), 200)]
    public async Task<IActionResult> SearchCategory(
        [FromServices] SearchCategoriesHandler handler,
        CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await handler.Fetch(cancellationToken));
        }
        catch (Exception)
        {
            // TODO: Log
            throw;
        }
    }

    #endregion Category


    #region Brand

    #endregion Brand
}
