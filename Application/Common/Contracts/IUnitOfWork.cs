namespace Application.Common.Contracts;

public interface IUnitOfWork
{
    bool Commit();
    Task<bool> CommitAsync(CancellationToken cancellationToken = default);
    void Rollback();
    Task RollbackAsync();
}