using Domain.Shadred;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public int CommitChanges()
    {
        int result = _context.SaveChanges();
        return result;
    }

    public async Task<int> CommitChangesAsync(CancellationToken ct)
    {
        int result = await _context.SaveChangesAsync();
        return result;
    }
}
