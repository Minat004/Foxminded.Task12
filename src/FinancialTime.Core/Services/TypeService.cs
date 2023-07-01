using FinancialTime.Core.Interfaces;
using FinancialTime.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialTime.Core.Services;

public class TypeService : ITypeService
{
    private readonly IFinanceDbContext _dbContext;

    public TypeService(IFinanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<FinType>> GetAllAsync()
    {
        return await _dbContext.FinTypes.ToListAsync();
    }

    public async Task<FinType> GetByIdAsync(int id)
    {
        var item = await _dbContext.FinTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (item is null)
        {
            throw new NullReferenceException();
        }

        return item;
    }

    public async Task AddAsync(FinType item)
    {
        _dbContext.FinTypes.Add(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditAsync(FinType item)
    {
        _dbContext.FinTypes.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(FinType item)
    {
        _dbContext.FinTypes.Remove(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<FinOperation>> GetOperations(FinType item)
    {
        return await _dbContext.FinOperations.Where(x => x.FinTypeId == item.Id).ToListAsync();
    }
}