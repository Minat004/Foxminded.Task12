namespace FinancialTime.WebAPI.DTOs.FinOperation;

public class FinOperationEditDto
{
    public decimal Value { get; set; }

    public DateTime Date { get; set; }
    
    public int FinTypeId { get; set; }
}