using FinancialTime.Core.Models;

namespace FinancialTime.WebAPI.DTOs.FinOperation;

public class FinOperationDto
{
    public int Value { get; set; }

    public DateTime Date { get; set; }

    public string? FinTypeName { get; set; }

    public string? FinTypeBudget { get; set; }
}