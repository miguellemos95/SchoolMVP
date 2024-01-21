using Application.Common.Contracts;

namespace Persistence.Common;

internal class UnitOfWork : IUnitOfWork
{
    private readonly CoreContext _context;

    public UnitOfWork(CoreContext context)
    {
        _context = context;
    }

    public bool Commit()
        => _context.SaveChanges() > 0;

    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken) > 0;

    public void Rollback()
        => _context.Dispose();

    public async Task RollbackAsync()
        => await _context.DisposeAsync();
}