using FinancialTime.Core.Models;

namespace FinancialTime.Core.Interfaces;

public interface IService<T>
{
    public Task<IEnumerable<T>> GetAllAsync();

    public Task<T> GetByIdAsync(int id);

    public Task AddAsync(T item);

    public Task EditAsync(T item);

    public Task DeleteAsync(T item);
}

public interface IOperationService : IService<FinOperation> { }

public interface ITypeService : IService<FinType>
{
    public Task<IEnumerable<FinOperation>> GetOperations(FinType item);
}