namespace Domain.Features.Products.DTOs;

public record ProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int AvailableStock,
    string Slug,
    int BrandId,
    int CategoryId
);
