using Domain.Common;

namespace Domain.Categories;
public class Category : BaseClass<int>
{
    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
}
