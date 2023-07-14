using System.Net;
using FinancialTime.BlazorServerApp.Interfaces;
using FinancialTime.BlazorServerApp.Settings;
using FinancialTime.Core.DTOs.FinOperation;
using Newtonsoft.Json;

namespace FinancialTime.BlazorServerApp.Clients;

public class HistoryClient : IHistoryClient
{
    private readonly HttpClient _httpClient;
    private readonly string? _finOperationUrl;

    public HistoryClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _finOperationUrl = configuration["FinanceConfiguration:FinOperation"];
    }

    public async Task<IEnumerable<FinOperationDto>?> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(_finOperationUrl);

        return JsonConvert.DeserializeObject<IEnumerable<FinOperationDto>>(await response.Content.ReadAsStringAsync());
    }

    public async Task AddAsync(FinOperationAddDto item)
    {
        var response = await _httpClient.PostAsJsonAsync(_finOperationUrl, item);
    }

    public async Task UpdateAsync(int id, FinOperationEditDto item)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_finOperationUrl}{id}", item);
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_finOperationUrl}{id}");
    }
}