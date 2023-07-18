using FinancialTime.BlazorServerApp.Interfaces;
using FinancialTime.Core.DTOs.FinType;
using Newtonsoft.Json;

namespace FinancialTime.BlazorServerApp.Clients;

public class CategoryClient : ICategoryClient
{
    private readonly HttpClient _httpClient;
    private readonly string? _finTypeUrl;

    public CategoryClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _finTypeUrl = "api/FinType/";
    }

    public async Task<IEnumerable<FinTypeDto>?> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(_finTypeUrl);

        if (!response.IsSuccessStatusCode) return default;

        return JsonConvert.DeserializeObject<IEnumerable<FinTypeDto>>(await response.Content.ReadAsStringAsync());
    }

    public async Task<FinTypeAddDto?> AddAsync(FinTypeAddDto item)
    {
        var response = await _httpClient.PostAsJsonAsync(_finTypeUrl, item);
        
        if (!response.IsSuccessStatusCode) return default;

        return JsonConvert.DeserializeObject<FinTypeAddDto>(await response.Content.ReadAsStringAsync());
    }

    public async Task<bool> UpdateAsync(int id, FinTypeEditDto item)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_finTypeUrl}{id}", item);

        if (!response.IsSuccessStatusCode)
        {
            return await Task.FromResult(false);
        }

        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_finTypeUrl}{id}");
        
        if (!response.IsSuccessStatusCode)
        {
            return await Task.FromResult(false);
        }

        return await Task.FromResult(true);
    }
}