using System.ComponentModel.DataAnnotations;
using FinancialTime.Core.Enums;

namespace FinancialTime.Core.Models;

public class FinType
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public EBudget Budget { get; set; }

    public bool IsDelete { get; set; }

    public ICollection<FinOperation>? ListOperations { get; set; }
}