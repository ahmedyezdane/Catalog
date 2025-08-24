using Domain.Shadred.Exceptions;

namespace Domain.Features.Products.Exceptions;

public class ProductPriceLessThanOrEqualToZeroException : DomainException
{
    public ProductPriceLessThanOrEqualToZeroException(string message) : base(message)
    {
    }
}
