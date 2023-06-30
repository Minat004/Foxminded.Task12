using FinancialTime.Core.Enums;
using FinancialTime.WebAPI.DTOs.FinOperation;

namespace FinancialTime.WebAPI.DTOs.FinType;

public class FinTypeDto
{
    public string Name { get; set; } = null!;

    public EBudget Budget { get; set; }

    public ICollection<FinOperationDto>? ListOperations { get; set; }
}