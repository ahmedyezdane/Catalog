namespace Domain.Features.Products.Commands;

public sealed record CreateCategoryCommand(
    string Name,
    int? ParentId
);