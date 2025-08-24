using Domain.Shadred.Helpers;

namespace Domain.Shadred.Exceptions;

public class NotFoundEntityException : DomainException
{
    public NotFoundEntityException(string entityName) 
        : base(string.Format(DomainErrors.NotFoundEntity,entityName))
    {
    }
}
