using Microsoft.EntityFrameworkCore;
using Savings.Domain.Entities;

namespace Savings.Infrastructure.Database;

internal class SavingsDbContext(DbContextOptions<SavingsDbContext> options) : DbContext(options)
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SavingsDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}
