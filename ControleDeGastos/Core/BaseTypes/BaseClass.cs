namespace Core.BaseTypes;
public class BaseClass<T>
{
    public BaseClass()
    {
        CreatedAt = DateTime.Now;
    }

    public T Id { get; set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; } = false;

    public void SetUpdateDate()
    {
        UpdatedAt = DateTime.Now;
    }

    public void SetAsDeleted()
    {
        IsDeleted = true;
        SetUpdateDate();
    }
}
