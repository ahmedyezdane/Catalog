using ApplicationService.Products.Handlers.BrandHandlers;
using ApplicationService.Products.Handlers.CategoryHandlers;
using ApplicationService.Products.Handlers.ProductHandlers;
using Domain.Features.Products.Commands;
using Domain.Features.Products.Commands.ProductCommands;
using Domain.Features.Products.DTOs;
using Domain.Shadred;using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
public class ProductsController : ControllerBase
{
    #region Brand

    [HttpPost("create-brand")]
    public async Task<IActionResult> CreateBrand(
        [FromServices] CreateBrandHandler handler,
        [FromBody] CreateBrandCommand command,
        CancellationToken cancellationToken)
    {
        await handler.Execute(command, cancellationToken);
        return Created();
    }

    [HttpPut("update-brand")]
    public async Task<IActionResult> UpdateBrand(
    [FromServices] UpdateBrandHandler handler,
    [FromBody] UpdateBrandCommand command,
    CancellationToken cancellationToken)
    {
        await handler.Execute(command, cancellationToken);
        return Created();
    }

    [HttpGet("search-brand")]
    [ProducesResponseType(typeof(PagedList<BrandDto>), 200)]
    public async Task<IActionResult> SearchBrand(
        [FromServices] SearchBrandsHandler handler,
        int pageNumber, int pageSize, string? filter,
        CancellationToken cancellationToken)
    {
        var dto = new BaseSearchDto(pageNumber, pageSize, filter);
        var result = await handler.Fetch(dto, cancellationToken);
        return Ok(result);
    }

    #endregion Brand

    #region Category

    [HttpPost("create-category")]
    public async Task<IActionResult> CreateCategory(
        [FromServices] CreateCategoryHandler handler,
        [FromBody] CreateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        await handler.Execute(command, cancellationToken);
        return Created();
    }

    [HttpPut("update-category")]
    public async Task<IActionResult> UpdateCategory(
        [FromServices] UpdateCategoryHandler handler,
        [FromBody] UpdateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        await handler.Execute(command, cancellationToken);
        return Created();
    }

    [HttpGet("search-category")]
    [ProducesResponseType(typeof(List<CategoryDto>), 200)]
    public async Task<IActionResult> SearchCategory(
        [FromServices] SearchCategoriesHandler handler,
        CancellationToken cancellationToken)
    {
        return Ok(await handler.Fetch(cancellationToken));
    }

    #endregion Category

    #region Product

    [HttpPost("create-product")]
    public async Task<IActionResult> CreateProduct(
        [FromServices] CreateProductHandler handler,
        [FromBody] CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        await handler.Execute(command, cancellationToken);
        return Created();
    }

    [HttpPut("update-product-price")]
    public async Task<IActionResult> UpdateProductPrice(
        [FromServices] UpdateProductPriceHandler handler,
        [FromBody] UpdateProductPriceCommand command,
        CancellationToken cancellationToken)
    {
        await handler.Execute(command, cancellationToken);
        return Created();
    }

    [HttpPut("update-product-stock")]
    public async Task<IActionResult> UpdateProductStock(
        [FromServices] UpdateProductStockHandler handler,
        [FromBody] UpdateProductStockCommand command,
        CancellationToken cancellationToken)
    {
        await handler.Execute(command, cancellationToken);
        return Created();
    }

    [HttpPost("add-product-media")]
    public async Task<IActionResult> AddProductMedia(
        [FromServices] AddProductMediaHandler handler,
        [FromBody] AddProductMediaCommand command,
        CancellationToken cancellationToken)
    {
        await handler.Execute(command, cancellationToken);
        return Created();
    }

    [HttpGet("search-product")]
    [ProducesResponseType(typeof(PagedList<ProductDto>), 200)]
    public async Task<IActionResult> SearchProduct(
        [FromServices] SearchProductsHandler handler,
        int pageNumber, int pageSize, string? filter,
        CancellationToken cancellationToken)
    {
        var dto = new BaseSearchDto(pageNumber, pageSize, filter);
        return Ok(await handler.Fetch(dto, cancellationToken));
    }

    #endregion Product
}
