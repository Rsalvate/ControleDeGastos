using Data.Contexts;
using Data.Repositories.Abstractions;
using Domain.Categories;
using Domain.Categories.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Categories;
internal sealed class CategoryRepository : CrudRepository<Category, int>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    protected override IQueryable<Category> Query => base.Query;

    public Task<Category?> FindByName(string name)
    {
        return Query.FirstOrDefaultAsync(f => f.Name == name);
    }
}
