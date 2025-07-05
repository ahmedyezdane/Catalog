namespace Domain.Shadred.Exceptions;

public class NotFoundEntityException : Exception
{
    public NotFoundEntityException(string entityName) : base(entityName)
    {
    }
}
