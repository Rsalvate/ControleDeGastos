namespace Core.PagedSearch;
public class PagedSearchList<TEntity>
{
    public long TotalResults { get; set; }

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public IList<TEntity> List { get; set; }
}
