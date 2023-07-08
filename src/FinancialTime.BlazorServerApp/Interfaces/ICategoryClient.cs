using FinancialTime.Core.DTOs.FinType;

namespace FinancialTime.BlazorServerApp.Interfaces;

public interface ICategoryClient
{
    public Task<IEnumerable<FinTypeDto>?> GetAllAsync();

    public Task AddAsync(FinTypeAddDto item);

    public Task UpdateAsync(int id, FinTypeEditDto item);

    public Task DeleteAsync(int id);
}