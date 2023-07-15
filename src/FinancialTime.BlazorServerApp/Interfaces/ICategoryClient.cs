using FinancialTime.Core.DTOs.FinType;

namespace FinancialTime.BlazorServerApp.Interfaces;

public interface ICategoryClient
{
    public Task<IEnumerable<FinTypeDto>?> GetAllAsync();

    public Task<FinTypeAddDto?> AddAsync(FinTypeAddDto item);

    public Task<bool> UpdateAsync(int id, FinTypeEditDto item);

    public Task<bool> DeleteAsync(int id);
}