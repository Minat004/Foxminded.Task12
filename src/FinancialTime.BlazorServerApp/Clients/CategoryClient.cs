using FinancialTime.BlazorServerApp.Interfaces;
using FinancialTime.Core.DTOs.FinType;
using Newtonsoft.Json;

namespace FinancialTime.BlazorServerApp.Clients;

public class CategoryClient : ICategoryClient
{
    private readonly HttpClient _httpClient;

    public CategoryClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<FinTypeDto>?> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("");

        return JsonConvert.DeserializeObject<IEnumerable<FinTypeDto>>(await response.Content.ReadAsStringAsync());
    }

    public async Task AddAsync(FinTypeAddDto item)
    {
        await _httpClient.PostAsJsonAsync("", item); 
    }

    public async Task UpdateAsync(int id, FinTypeEditDto item)
    {
        var response = await _httpClient.PutAsJsonAsync($"{id}", item);
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{id}");
    }
}