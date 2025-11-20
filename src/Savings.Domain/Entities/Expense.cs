using Savings.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Savings.Domain.Entities;

[Table("expenses")]
public class Expense
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
    [Column("title")]
    public string Title { get; set; } = string.Empty;
    [Column("description")]
    public string? Description { get; set; }
    [Column("amount", TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    [Column("expense_type")]
    public ExpenseType ExpenseType { get; set; }
    [Column("date")]
    public DateTime Date { get; set; }
}
