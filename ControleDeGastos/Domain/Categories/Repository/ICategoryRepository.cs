using Core.Repositories;

namespace Domain.Categories.Repository;
public interface ICategoryRepository : ICrudRepository<Category, int>, ISearchableRepository<Category, int>
{
    Task<Category?> FindByName(string name);
}
