using FinancialTime.Core.Enums;
using FinancialTime.Core.Interfaces;
using FinancialTime.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialTime.Core.Services;

public class ReportService : IReportService
{
    private readonly IFinanceDbContext _dbContext;

    public ReportService(IFinanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Report> GetDateReport(DateTime date)
    {
        var resultIncome = await _dbContext.FinOperations
            .Where(x => x.Date == date && x.FinType.Budget == EBudget.Income)
            .Select(x => x.Value)
            .SumAsync();
        
        var resultExpense = await _dbContext.FinOperations
            .Where(x => x.Date == date && x.FinType.Budget == EBudget.Expense)
            .Select(x => x.Value)
            .SumAsync();

        var operations = await _dbContext.FinOperations
            .Where(x => x.Date == date)
            .ToListAsync();
        
        var report = new Report()
        {
            StartDate = date,
            ResultIncome = resultIncome,
            ResultExpense = resultExpense,
            Operations = operations
        };

        return report;
    }

    public async Task<Report> GetPeriodReport(DateTime startDate, DateTime endDate)
    {
        var resultIncome = await _dbContext.FinOperations
            .Where(x => x.Date >= startDate && x.Date <= endDate && x.FinType.Budget == EBudget.Income)
            .Select(x => x.Value)
            .SumAsync();
        
        var resultExpense = await _dbContext.FinOperations
            .Where(x => x.Date >= startDate && x.Date <= endDate && x.FinType.Budget == EBudget.Expense)
            .Select(x => x.Value)
            .SumAsync();

        var operations = await _dbContext.FinOperations
            .Where(x => x.Date >= startDate && x.Date <= endDate)
            .ToListAsync();
        
        var report = new Report()
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