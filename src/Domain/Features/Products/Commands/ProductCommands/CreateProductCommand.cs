namespace Domain.Features.Products.Commands.ProductCommands;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    int BrandId,
    int CategoryId,
    decimal Price,
    int AvailableStock
);