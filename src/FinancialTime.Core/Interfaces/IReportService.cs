using FinancialTime.Core.Models;

namespace FinancialTime.Core.Interfaces;

public interface IReportService
{
    public Task<Report> GetDateReport(DateTime date);
    
    public Task<Report> GetPeriodReport(DateTime startDate, DateTime endDate);
}