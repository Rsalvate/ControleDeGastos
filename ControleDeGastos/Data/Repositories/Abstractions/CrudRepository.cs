using Core.BaseTypes;
using Core.PagedSearch;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Data.Repositories.Abstractions;
public abstract class CrudRepository<TEntity, TEntityKey> :
    Repository<TEntity, TEntityKey>,
    ICrudRepository<TEntity, TEntityKey>,
    ISearchableRepository<TEntity, TEntityKey>
    where TEntity : BaseClass<TEntityKey>
{
    protected CrudRepository(DbContext context) : base(context)
    {
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        EntityEntry<TEntity> entityEntry = await this.DbSet.AddAsync(entity);
    }

    public virtual Task AddAsync(IList<TEntity> entities) => this.DbSet.AddRangeAsync((IEnumerable<TEntity>)entities);

    public virtual Task UpdateAsync(TEntity entity)
    {
        this.DbSet.Update(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(IList<TEntity> entities)
    {
        this.DbSet.UpdateRange((IEnumerable<TEntity>)entities);
        return Task.CompletedTask;
    }

    public virtual async Task DeleteAsync(TEntityKey id)
    {
        TEntity entity = await this.DbSet.FindAsync((object)id);
        TEntity obj = entity;
        entity = default(TEntity);
        this.DbSet.Remove(obj);
        obj = default(TEntity);
    }

    public Task DeleteAsync(TEntity entity)
    {
        this.DbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(IList<TEntity> entities)
    {
        this.DbSet.RemoveRange((IEnumerable<TEntity>)entities);
        return Task.CompletedTask;
    }

    public Task<List<TEntity>> FindAllAsync() => this.Query.ToListAsync();

    public async Task<PagedSearchList<TEntity>> FindAllPagedAsync(int currentPage, int pageSize)
    {
        int count = await this.Query.CountAsync();
        List<TEntity> data = await this.Query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        PagedSearchList<TEntity> pagedDataAsync = new PagedSearchList<TEntity>()
        {
            TotalResults = (long)count,
            CurrentPage = currentPage,
            PageSize = pageSize,
            List = (IList<TEntity>)data
        };

        data = (List<TEntity>)null;

        return pagedDataAsync;
    }

    public Task<TEntity> FindByIdAsync(TEntityKey id) => this.Query.FirstOrDefaultAsync<TEntity>((Expression<Func<TEntity, bool>>)(x => x.Id.Equals((object)id)));

    public Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate) => this.Query.Where(predicate).ToListAsync();

    public async Task<PagedSearchList<TEntity>> SearchPagedAsync(Expression<Func<TEntity, bool>> predicate, int currentPage, int pageSize)
    {
        IQueryable<TEntity> query = this.Query.Where<TEntity>(predicate);
        int count = await query.CountAsync<TEntity>();
        List<TEntity> data = await query.Skip<TEntity>((currentPage - 1) * pageSize).Take<TEntity>(pageSize).ToListAsync<TEntity>();
        PagedSearchList<TEntity> pagedSearchList = new PagedSearchList<TEntity>()
        {
            TotalResults = (long)count,
            CurrentPage = currentPage,
            PageSize = pageSize,
            List = (IList<TEntity>)data
        };
        query = (IQueryable<TEntity>)null;
        data = (List<TEntity>)null;
        return pagedSearchList;
    }
}
