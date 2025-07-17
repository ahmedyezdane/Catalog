namespace Domain.Shadred;

public interface IUnitOfWork
{
    int CommitChanges();

    Task<int> CommitChangesAsync(CancellationToken ct);
}
