using Core.BaseTypes;
using Core.PagedSearch;
using System.Linq.Expressions;

namespace Core.Repositories;
public interface ISearchableRepository<TEntity, TEntityKey> : IRepository where TEntity : BaseClass<TEntityKey>
{
    Task<TEntity> FindByIdAsync(TEntityKey id);
    Task<List<TEntity>> FindAllAsync();
    Task<PagedSearchList<TEntity>> FindAllPagedAsync(int currentPage, int pageSize);

    Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate);

    Task<PagedSearchList<TEntity>> SearchPagedAsync(
      Expression<Func<TEntity, bool>> predicate,
      int currentPage,
      int pageSize);
}
