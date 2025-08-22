namespace Domain.Features.Products.DTOs;

public sealed record CategoryDto(
    int Id,
    string Name,
    int? ParentId
);