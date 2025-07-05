namespace Domain.Features.Products.Commands;

public record CreateBrandCommand(
    string Name,
    string LogoUrl
);
