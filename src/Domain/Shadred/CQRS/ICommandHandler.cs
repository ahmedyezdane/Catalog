namespace Domain.Shadred.CQRS;

public interface ICommandHandler<in TCommand, TOut>
{
    Task<TOut> Execute(TCommand command, CancellationToken cancellationToken);
}
