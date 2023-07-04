namespace FinancialTime.Core.DTOs.FinOperation;

public class FinOperationDto
{
    public decimal Value { get; set; }

    public DateTime Date { get; set; }

    public string? FinTypeName { get; set; }

    public string? FinTypeBudget { get; set; }
}