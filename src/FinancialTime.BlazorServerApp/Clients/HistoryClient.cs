using FinancialTime.BlazorServerApp.Interfaces;
using FinancialTime.Core.DTOs.FinOperation;
using Newtonsoft.Json;

namespace FinancialTime.BlazorServerApp.Clients;

public class HistoryClient : IHistoryClient
{
    private readonly HttpClient _httpClient;

    public HistoryClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<FinOperationDto>?> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("");

        return JsonConvert.DeserializeObject<IEnumerable<FinOperationDto>>(await response.Content.ReadAsStringAsync());
    }

    public async Task AddAsync(FinOperationAddDto item)
    {
        await _httpClient.PostAsJsonAsync("", item); 
    }

    public async Task UpdateAsync(int id, FinOperationEditDto item)
    {
        var response = await _httpClient.PutAsJsonAsync($"{id}", item);
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{id}");
    }
}