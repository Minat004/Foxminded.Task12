using AutoMapper;
using FinancialTime.Core.DTOs.FinOperation;
using FinancialTime.Core.Interfaces;
using FinancialTime.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialTime.Core.Services;

public class OperationService : IOperationService
{
    private readonly IFinanceDbContext _dbContext;
    private readonly IMapper _mapper;

    public OperationService(IFinanceDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FinOperationDto>> GetAllAsync()
    {
        var items = await _dbContext.FinOperations
            .Where(x => !x.IsDelete)
            .Include(x => x.FinType)
            .ToListAsync();
        
        var itemDtos = _mapper.Map<IEnumerable<FinOperationDto>>(items);
        
        return itemDtos;
    }

    public async Task<FinOperationDto> GetByIdAsync(int id)
    {
        var item = await _dbContext.FinOperations
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDelete);

        if (item is null)
        {
            throw new NullReferenceException();
        }
        
        var itemDto = _mapper.Map<FinOperationDto>(item);
        
        return itemDto;
    }

    public async Task AddAsync(FinOperationAddDto itemDto)
    {
        var item = _mapper.Map<FinOperation>(itemDto);
        
        _dbContext.FinOperations.Add(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditAsync(int id, FinOperationEditDto itemDto)
    {
        if (await _dbContext.FinOperations.FirstOrDefaultAsync(x => x.Id == id) is null)
        {
            throw new NullReferenceException();
        }
        
        var item = _mapper.Map<FinOperation>(itemDto);
        
        _dbContext.FinOperations.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _dbContext.FinOperations.FirstOrDefaultAsync(x => x.Id == id);
        
        if (item is null)
        {
            throw new NullReferenceException();
        }

        item.IsDelete = true;
        
        _dbContext.FinOperations.Update(item);
        await _dbContext.SaveChangesAsync();
    }
}