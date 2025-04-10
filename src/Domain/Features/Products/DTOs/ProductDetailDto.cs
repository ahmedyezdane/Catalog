using Domain.Features.Products.ValueObjects;

namespace Domain.Features.Products.DTOs;
public record ProductDetailDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int AvailableStock,
    string Slug,
    int BrandId,
    string BrandName,
    int CategoryId,
    string CategoryName,
    List<Media> Medias
);