using Domain.Shadred.Exceptions;

namespace Domain.Features.Products.Exceptions;

public class ProductStockNegativeQuantityException : DomainException
{
    public ProductStockNegativeQuantityException(string message) : base(message)
    {
    }
}
