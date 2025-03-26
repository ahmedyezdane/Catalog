namespace Domain.Shadred;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
}

public abstract class BaseEntity : BaseEntity<int> { }