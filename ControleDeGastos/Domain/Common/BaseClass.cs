namespace Domain.Common;
public class BaseClass<T>
{
    public BaseClass()
    {
        CreatedAt = DateTime.Now;
    }

    public T Id { get; set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void SetUpdateDate()
    {
        UpdatedAt = DateTime.Now;
    }
}
