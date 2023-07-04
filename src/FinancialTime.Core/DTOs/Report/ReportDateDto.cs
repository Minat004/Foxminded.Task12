using FinancialTime.Core.DTOs.FinOperation;

namespace FinancialTime.Core.DTOs.Report;

public class ReportDateDto
{
    public DateTime? Date { get; set; }

    public decimal ResultIncome { get; set; }
    
    public decimal ResultExpense { get; set; }

    public IEnumerable<FinOperationDto>? Operations { get; set; }
}