using FinancialTime.Core.Interfaces;
using FinancialTime.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialTime.Core.Services;

public class OperationService : IOperationService
{
    private readonly IFinanceDbContext _dbContext;

    public OperationService(IFinanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<FinOperation>> GetAllAsync()
    {
        return await _dbContext.FinOperations.Include(x => x.FinType).ToListAsync();
    }

    public async Task<FinOperation> GetByIdAsync(int id)
    {
        var item = await _dbContext.FinOperations.FirstOrDefaultAsync(x => x.Id == id);

        if (item is null)
        {
            throw new NullReferenceException();
        }
        
        return item;
    }

    public async Task AddAsync(FinOperation item)
    {
        _dbContext.FinOperations.Add(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditAsync(FinOperation item)
    {
        _dbContext.FinOperations.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(FinOperation item)
    {
        _dbContext.FinOperations.Remove(item);
        await _dbContext.SaveChangesAsync();
    }
}