namespace Domain.Shadred.Exceptions;

public abstract class DomainException : Exception
{
    protected DomainException(string message):base(message)
    {
        Message = message;
    }

    public string Message { get; init; }
}
