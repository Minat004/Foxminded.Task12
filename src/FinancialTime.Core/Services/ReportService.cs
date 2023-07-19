using FinancialTime.Core.Enums;
using FinancialTime.Core.Interfaces;
using FinancialTime.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FinancialTime.Core.Services;

public class ReportService : IReportService
{
    private readonly IFinanceDbContext _dbContext;

    public ReportService(IFinanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ReportViewModel> GetDateReport(DateTime date)
    {
        var operations = await _dbContext.FinOperations
            .Include(x => x.FinType)
            .Where(x => x.Date.Date == date.Date)
            .ToListAsync();

        var resultIncome = operations
            .Where(x => x.FinType.Budget == EBudget.Income)
            .Select(x => x.Value)
            .Sum();
        
        var resultExpense = operations
            .Where(x => x.FinType.Budget == EBudget.Expense)
            .Select(x => x.Value)
            .Sum();

        var report = new ReportViewModel()
        {
            StartDate = date,
            ResultIncome = resultIncome,
            ResultExpense = resultExpense,
            Operations = operations
        };

        return report;
    }

    public async Task<ReportViewModel> GetPeriodReport(DateTime startDate, DateTime endDate)
    {
        var operations = await _dbContext.FinOperations
            .Include(x => x.FinType)
            .Where(x => x.Date.Date >= startDate.Date && x.Date.Date <= endDate.Date)
            .ToListAsync();
        
        var resultIncome = operations
            .Where(x => x.FinType.Budget == EBudget.Income)
            .Select(x => x.Value)
            .Sum();

        var resultExpense = operations
            .Where(x => x.FinType.Budget == EBudget.Expense)
            .Select(x => x.Value)
            .Sum();

        var report = new ReportViewModel()
        {
            StartDate = startDate,
            EndDate = endDate,
            ResultIncome = resultIncome,
            ResultExpense = resultExpense,
            Operations = operations
        };

        return report;
    }
}