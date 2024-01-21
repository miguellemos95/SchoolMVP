using Application.Common.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Common;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<TEntity>
{
    private readonly CoreContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(CoreContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual TEntity? Get(Expression<Func<TEntity, bool>> expression)
        => _dbSet.FirstOrDefault(expression);

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
        => await _dbSet.FirstOrDefaultAsync(expression);

    public virtual IEnumerable<TEntity> GetAll()
        => _dbSet;

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        => _dbSet.Where(expression);

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        => await _dbSet.Where(expression).ToListAsync();

    public virtual void Insert(TEntity entity)
        => _context.Add(entity);

    public virtual void Delete(TEntity entityToDelete)
        => _context.Remove(entityToDelete);

    public virtual void Update(TEntity entityToUpdate)
        => _context.Update(entityToUpdate);
}