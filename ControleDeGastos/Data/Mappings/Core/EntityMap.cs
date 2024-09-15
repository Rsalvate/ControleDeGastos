using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace Data.Mappings.Core;
public abstract class EntityMap<TEntity, TEntityKey> : IEntityTypeConfiguration<TEntity> where TEntity : BaseClass<TEntityKey>
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey((Expression<Func<TEntity, object>>)(x => (object)x.Id));
        builder.Property<TEntityKey>((Expression<Func<TEntity, TEntityKey>>)(x => x.Id)).ValueGeneratedOnAdd();

        this.ConfigureEntityBuilder(builder);
    }

    public abstract void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder);
}
