namespace Domain.Shadred;

public interface IUnitOfWork
{
    Result<int> CommitChanges();

    Task<Result<int>> CommitChangesAsync(CancellationToken ct);
}
