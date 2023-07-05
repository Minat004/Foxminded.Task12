using FinancialTime.Core.DTOs.FinOperation;
using FinancialTime.Core.DTOs.FinType;
using FinancialTime.Core.Models;

namespace FinancialTime.Core.Interfaces;

public interface IService<TModel>
{
    public Task<IEnumerable<TModel>> GetAllAsync();

    public Task<TModel> GetByIdAsync(int id);

    public Task DeleteAsync(int id);
}

public interface IOperationService : IService<FinOperationDto>
{
    public Task AddAsync(FinOperationAddDto itemDto);

    public Task EditAsync(int id, FinOperationEditDto itemDto);
}

public interface ITypeService : IService<FinTypeDto>
{
    public Task AddAsync(FinTypeAddDto itemDto);

    public Task EditAsync(int id, FinTypeEditDto itemDto);
    
    public Task<IEnumerable<FinOperationDto>> GetOperations(int finTypeId);
}