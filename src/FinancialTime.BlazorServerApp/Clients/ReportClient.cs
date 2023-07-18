using FinancialTime.BlazorServerApp.Interfaces;
using FinancialTime.Core.DTOs.Report;
using Newtonsoft.Json;

namespace FinancialTime.BlazorServerApp.Clients;

public class ReportClient : IReportClient
{
    private readonly HttpClient _httpClient;

    public ReportClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ReportDateDto?> GetDateReportAsync(DateTime date)
    {
        var response = await _httpClient.GetAsync($"report?date={date:dd.MM.yyyy}");
        
        if (!response.IsSuccessStatusCode) return default;

        return JsonConvert.DeserializeObject<ReportDateDto>(await response.Content.ReadAsStringAsync());
    }

    public async Task<ReportPeriodDto?> GetPeriodReportAsync(DateTime startDate, DateTime endDate)
    {
        var response = await _httpClient.GetAsync($"period-report?startDate={startDate:dd.MM.yyyy}&endDate={endDate:dd.MM.yyyy}");
        
        if (!response.IsSuccessStatusCode) return default;

        return JsonConvert.DeserializeObject<ReportPeriodDto>(await response.Content.ReadAsStringAsync());
    }
}