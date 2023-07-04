using FinancialTime.Core.DTOs.FinOperation;

namespace FinancialTime.Core.DTOs.Report;

public class ReportPeriodDto
{
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal ResultIncome { get; set; }
    
    public decimal ResultExpense { get; set; }

    public IEnumerable<FinOperationDto>? Operations { get; set; }
}