
using Core.BaseTypes;

namespace Core.Repositories;
public interface ICrudRepository<TEntity, TEntityKey> : IRepository where TEntity : BaseClass<TEntityKey>
{
    Task AddAsync(TEntity entity);
    Task AddAsync(IList<TEntity> entities);

    Task UpdateAsync(TEntity entity);
    Task UpdateAsync(IList<TEntity> entities);

    Task DeleteAsync(TEntityKey id);
    Task DeleteAsync(TEntity entity);
    Task DeleteAsync(IList<TEntity> entities);   
}
