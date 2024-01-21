using System.Linq.Expressions;

namespace Application.Common.Contracts;

public interface IRepository<TEntity> where TEntity : class
{
    TEntity? Get(Expression<Func<TEntity, bool>> expression);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    IEnumerable<TEntity> GetAll();
    Task<IEnumerable<TEntity>> GetAllAsync();
    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
    void Insert(TEntity entity);
    void Update(TEntity entityToUpdate);
    void Delete(TEntity entityToDelete);
}