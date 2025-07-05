namespace Domain.Shadred.CQRS;

public interface ICommandHandler<in TCommand, TOut>
{
    Task<TOut> Execute(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand>
{
    Task Execute(TCommand command, CancellationToken cancellationToken);
}
