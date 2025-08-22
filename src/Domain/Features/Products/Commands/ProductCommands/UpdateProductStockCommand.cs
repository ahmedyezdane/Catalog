namespace Domain.Features.Products.Commands.ProductCommands;

public sealed record UpdateProductStockCommand(
    int Id,
    int NewQuantity
);