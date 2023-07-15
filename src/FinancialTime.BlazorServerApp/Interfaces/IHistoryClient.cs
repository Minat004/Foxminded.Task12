using FinancialTime.Core.DTOs.FinOperation;

namespace FinancialTime.BlazorServerApp.Interfaces;

public interface IHistoryClient
{
    public Task<IEnumerable<FinOperationDto>?> GetAllAsync();
    
    public Task<FinOperationAddDto?> AddAsync(FinOperationAddDto item);
    
    public Task<bool> UpdateAsync(int id, FinOperationEditDto item);
    
    public Task<bool> DeleteAsync(int id);
}