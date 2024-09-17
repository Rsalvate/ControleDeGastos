using Data.Extensions;
using Domain.Categories;
using Domain.Expenses;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyMappings(GetType().Assembly);
        modelBuilder.ApplyVarcharConvention();
        modelBuilder.ApplyDateTimeConvention();
    }
}
