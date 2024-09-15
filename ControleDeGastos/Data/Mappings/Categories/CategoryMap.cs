using Data.Mappings.Core;
using Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings.Categories;
public class CategoryMap : EntityMap<Category, int>
{
    public override void ConfigureEntityBuilder(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(500).IsRequired();
    }
}
