namespace Domain.Shadred.CQRS;

public interface IQueryHandler<in TQuery, TOut>
{
    Task<TOut> Fetch(TQuery query, CancellationToken cancellationToken);
}
public interface IQueryHandler<TOut>
{
    Task<TOut> Fetch(CancellationToken cancellationToken);
}