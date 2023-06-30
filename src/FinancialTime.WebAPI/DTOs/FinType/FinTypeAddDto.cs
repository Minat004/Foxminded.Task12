using FinancialTime.Core.Enums;

namespace FinancialTime.WebAPI.DTOs.FinType;

public class FinTypeAddDto
{
    public string Name { get; set; } = null!;

    public EBudget Budget { get; set; }
}