namespace Domain;

public interface IEntity<TEntity> where TEntity : class
{ 
    Guid Id { get; init; }
    void Update(TEntity entity);
}