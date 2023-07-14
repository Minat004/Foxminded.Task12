using System.ComponentModel.DataAnnotations;
using FinancialTime.Core.DTOs.FinOperation;

namespace FinancialTime.Core.DTOs.FinType;

public class FinTypeDto
{
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^[\p{L}\p{Mn}]+$")]
    public string Name { get; set; } = null!;

    [Required]
    public string Budget { get; set; } = null!;

    public ICollection<FinOperationDto>? ListOperations { get; set; }
}