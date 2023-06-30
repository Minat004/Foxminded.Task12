using FinancialTime.Core.Enums;

namespace FinancialTime.WebAPI.DTOs.FinType;

public class FinTypeEditDto
{
    public string Name { get; set; } = null!;

    public EBudget Budget { get; set; }
}