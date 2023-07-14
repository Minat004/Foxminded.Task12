using System.Net;
using FinancialTime.BlazorServerApp.Interfaces;
using FinancialTime.BlazorServerApp.Settings;
using FinancialTime.Core.DTOs.FinType;
using Newtonsoft.Json;

namespace FinancialTime.BlazorServerApp.Clients;

public class CategoryClient : ICategoryClient
{
    private readonly HttpClient _httpClient;
    private readonly string? _finTypeUrl;

    public CategoryClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _finTypeUrl = configuration["FinanceConfiguration:FinType"];
    }

    public async Task<IEnumerable<FinTypeDto>?> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(_finTypeUrl);

        return JsonConvert.DeserializeObject<IEnumerable<FinTypeDto>>(await response.Content.ReadAsStringAsync());
    }

    public async Task AddAsync(FinTypeAddDto item)
    {
        var response = await _httpClient.PostAsJsonAsync(_finTypeUrl, item);
    }

    public async Task UpdateAsync(int id, FinTypeEditDto item)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_finTypeUrl}{id}", item);
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_finTypeUrl}{id}");
    }
}