namespace FinancialTime.WebAPI.DTOs.FinOperation;

public class FinOperationAddDto
{
    public int Value { get; set; }

    public DateTime Date { get; set; }
    
    public int FinTypeId { get; set; }
}