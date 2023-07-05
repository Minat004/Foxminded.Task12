using System.ComponentModel.DataAnnotations;

namespace FinancialTime.Core.DTOs.FinOperation;

public class FinOperationAddDto
{
    [Required]
    [Range(0, int.MaxValue)]
    public decimal Value { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public int FinTypeId { get; set; }
}