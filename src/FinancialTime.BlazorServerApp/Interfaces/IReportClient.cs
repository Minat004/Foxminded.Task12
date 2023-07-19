using FinancialTime.Core.DTOs.Report;

namespace FinancialTime.BlazorServerApp.Interfaces;

public interface IReportClient
{
    public Task<ReportDateDto?> GetDateReportAsync(DateTime date);

    public Task<ReportPeriodDto?> GetPeriodReportAsync(DateTime startDate, DateTime endDate);
}