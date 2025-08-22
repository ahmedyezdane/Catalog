namespace Domain.Features.Products.Commands;

public sealed record UpdateCategoryCommand(
    int Id,
    string Name
);