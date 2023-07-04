using System.ComponentModel.DataAnnotations;
using FinancialTime.Core.Enums;

namespace FinancialTime.Core.DTOs.FinType;

public class FinTypeEditDto
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public EBudget Budget { get; set; }
}