using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savings.Domain.Entities;

namespace Savings.Infrastructure.Database.Maps;

public class ExpenseMap : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("expenses");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Title)
            .HasColumnName("title")
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Description)
            .IsRequired(false)
            .HasColumnName("description")
            .HasMaxLength(1000);

        builder.Property(e => e.Amount)
            .IsRequired()
            .HasColumnName("amount")
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.ExpenseType)
            .IsRequired()
            .HasColumnName("expense_type");

        builder.Property(e => e.Date)
            .IsRequired()
            .HasColumnName("date");
    }
}
