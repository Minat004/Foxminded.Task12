namespace FinancialTime.Core.Models;

public class Report
{
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal ResultIncome { get; set; }
    
    public decimal ResultExpense { get; set; }

    public IEnumerable<FinOperation>? Operations { get; set; }
}