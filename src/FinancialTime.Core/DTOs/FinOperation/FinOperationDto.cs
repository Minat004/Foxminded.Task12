namespace FinancialTime.Core.DTOs.FinOperation;

public class FinOperationDto
{
    public int Id { get; set; }
    
    public decimal Value { get; set; }

    public DateTime Date { get; set; }

    public int FinTypeId { get; set; }

    public string? FinTypeName { get; set; }

    public string? FinTypeBudget { get; set; }
}