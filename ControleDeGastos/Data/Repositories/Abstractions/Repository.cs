using Core.BaseTypes;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Abstractions;
public abstract class Repository<TEntity, TEntityKey> : IRepository where TEntity : BaseClass<TEntityKey>
{
    protected readonly DbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected virtual IQueryable<TEntity> Query => (IQueryable<TEntity>)this.Context.Set<TEntity>();

    protected Repository(DbContext context)
    {
        this.Context = context;
        this.DbSet = this.Context.Set<TEntity>();
    }

    public void Dispose() => this.Context.Dispose();
}
