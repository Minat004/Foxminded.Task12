using FinancialTime.BlazorServerApp.Interfaces;
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

        if (!response.IsSuccessStatusCode)
        {
            throw new BadHttpRequestException($"Status code: {response.StatusCode}");
        }
        
        return JsonConvert.DeserializeObject<IEnumerable<FinTypeDto>>(await response.Content.ReadAsStringAsync());
    }

    public async Task AddAsync(FinTypeAddDto item)
    {
        var response = await _httpClient.PostAsJsonAsync(_finTypeUrl, item);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new BadHttpRequestException($"Status code: {response.StatusCode}");
        }
    }

    public async Task UpdateAsync(int id, FinTypeEditDto item)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_finTypeUrl}{id}", item);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new BadHttpRequestException($"Status code: {response.StatusCode}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_finTypeUrl}{id}");
        
        if (!response.IsSuccessStatusCode)
        {
            throw new BadHttpRequestException($"Status code: {response.StatusCode}");
        }
    }
}