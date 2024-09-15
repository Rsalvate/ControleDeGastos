using Data.Mappings.Core;
using Domain.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings.Expenses;
public class ExpenseMap : EntityMap<Expense, Guid>
{
    public override void ConfigureEntityBuilder(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("expenses");
        builder.Property(p=>p.Title).HasMaxLength(100).IsRequired();
        builder.Property(p=>p.Amount).HasPrecision(10,2).IsRequired();
        builder.Property(p=>p.DueDate).IsRequired();
        builder.Property(p=>p.PaymentDate).IsRequired(false);
        builder.Property(p=>p.IsPaid).IsRequired();
       
        builder.Property(p=>p.UserId).IsRequired();
        builder.HasOne(p=>p.User).WithMany().HasForeignKey(p=>p.UserId);

        builder.Property(p => p.CategoryId).IsRequired();
        builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId);
    }
}
