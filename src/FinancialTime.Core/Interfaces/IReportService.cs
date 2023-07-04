using FinancialTime.Core.Models;
using FinancialTime.Core.ViewModels;

namespace FinancialTime.Core.Interfaces;

public interface IReportService
{
    public Task<ReportViewModel> GetDateReport(DateTime date);
    
    public Task<ReportViewModel> GetPeriodReport(DateTime startDate, DateTime endDate);
}