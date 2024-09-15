using Data.Mappings.Core;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings.Users;
public class UserMapping : EntityMap<User, Guid>
{
    public override void ConfigureEntityBuilder(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(200).IsRequired();
    }
}
