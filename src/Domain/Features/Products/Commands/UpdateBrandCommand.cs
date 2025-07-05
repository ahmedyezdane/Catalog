namespace Domain.Features.Products.Commands;

public record UpdateBrandCommand(
    int Id,
    string Name
);