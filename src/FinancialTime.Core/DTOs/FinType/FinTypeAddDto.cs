using System.ComponentModel.DataAnnotations;
using FinancialTime.Core.Enums;

namespace FinancialTime.Core.DTOs.FinType;

public class FinTypeAddDto
{
    [Required]
    [RegularExpression(@"^[\p{L}\p{Mn}]+$")]
    public string Name { get; set; } = null!;

    [Required]
    public EBudget Budget { get; set; }
}