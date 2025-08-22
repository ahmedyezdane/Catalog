namespace Domain.Features.Products.Commands.ProductCommands;

public sealed record AddProductMediaCommand(
    int Id,
    string Name,
    string Url
);