using FinancialTime.Core.DTOs.FinOperation;

namespace FinancialTime.BlazorServerApp.Interfaces;

public interface IHistoryClient
{
    public Task<IEnumerable<FinOperationDto>?> GetAllAsync();
    
    public Task AddAsync(FinOperationAddDto item);
    
    public Task UpdateAsync(int id, FinOperationEditDto item);
    
    public Task DeleteAsync(int id);
}