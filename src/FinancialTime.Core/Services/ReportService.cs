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
        var resultIncome = await _dbContext.FinOperations
            .Where(x => x.Date.Date == date.Date && x.FinType.Budget == EBudget.Income)
            .Select(x => x.Value)
            .SumAsync();
        
        var resultExpense = await _dbContext.FinOperations
            .Where(x => x.Date.Date == date.Date && x.FinType.Budget == EBudget.Expense)
            .Select(x => x.Value)
            .SumAsync();

        var operations = await _dbContext.FinOperations
            .Where(x => x.Date.Date == date.Date)
            .ToListAsync();
        
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
        var resultIncome = await _dbContext.FinOperations
            .Where(x => x.Date.Date >= startDate.Date && x.Date.Date <= endDate.Date
                                                      && x.FinType.Budget == EBudget.Income)
            .Select(x => x.Value)
            .SumAsync();
        
        var resultExpense = await _dbContext.FinOperations
            .Where(x => x.Date.Date >= startDate.Date && x.Date.Date <= endDate.Date
                                                      && x.FinType.Budget == EBudget.Expense)
            .Select(x => x.Value)
            .SumAsync();

        var operations = await _dbContext.FinOperations
            .Where(x => x.Date.Date >= startDate.Date && x.Date.Date <= endDate.Date)
            .ToListAsync();
        
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