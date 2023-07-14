using System.Net;
using FinancialTime.BlazorServerApp.Interfaces;
using FinancialTime.BlazorServerApp.Settings;
using FinancialTime.Core.DTOs.Report;
using Newtonsoft.Json;

namespace FinancialTime.BlazorServerApp.Clients;

public class ReportClient : IReportClient
{
    private readonly HttpClient _httpClient;
    private readonly string? _reportUrl;

    public ReportClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _reportUrl = configuration["FinanceConfiguration:Report"];
    }

    public async Task<ReportDateDto?> GetDateReportAsync(DateTime date)
    {
        var response = await _httpClient.GetAsync($"{_reportUrl}{date:dd.MM.yyyy}");

        return JsonConvert.DeserializeObject<ReportDateDto>(await response.Content.ReadAsStringAsync());
    }

    public async Task<ReportPeriodDto?> GetPeriodReportAsync(DateTime startDate, DateTime endDate)
    {
        var response = await _httpClient.GetAsync($"{_reportUrl}{startDate:dd.MM.yyyy}/{endDate:dd.MM.yyyy}");

        return JsonConvert.DeserializeObject<ReportPeriodDto>(await response.Content.ReadAsStringAsync());
    }
}