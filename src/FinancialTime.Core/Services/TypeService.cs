using AutoMapper;
using FinancialTime.Core.DTOs.FinOperation;
using FinancialTime.Core.DTOs.FinType;
using FinancialTime.Core.Exceptions;
using FinancialTime.Core.Interfaces;
using FinancialTime.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialTime.Core.Services;

public class TypeService : ITypeService
{
    private readonly IFinanceDbContext _dbContext;
    private readonly IMapper _mapper;

    public TypeService(IFinanceDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FinTypeDto>> GetAllAsync()
    {
        var items = await _dbContext.FinTypes
            .Where(x => !x.IsDelete)
            .Include(x => x.ListOperations)
            .ToListAsync();
        
        var itemDtos = _mapper.Map<IEnumerable<FinTypeDto>>(items);

        return itemDtos;
    }

    public async Task<FinTypeDto> GetByIdAsync(int id)
    {
        var item = await _dbContext.FinTypes
            .Include(x => x.ListOperations)
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDelete);

        if (item is null)
        {
            throw new NullReferenceException();
        }
        
        var itemDtos = _mapper.Map<FinTypeDto>(item);

        return itemDtos;
    }

    public async Task AddAsync(FinTypeAddDto itemDto)
    {
        if (await _dbContext.FinTypes.FirstOrDefaultAsync(x => x.Name == itemDto.Name) is not null)
        {
            throw new DuplicateTypeNameException(itemDto.Name);
        }
        
        var item = _mapper.Map<FinType>(itemDto);
        
        _dbContext.FinTypes.Add(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditAsync(int id, FinTypeEditDto itemDto)
    {
        var item = await _dbContext.FinTypes.FirstOrDefaultAsync(x => x.Id == id);
        
        if (item is null)
        {
            throw new NullReferenceException();
        }
        
        if (await _dbContext.FinTypes.FirstOrDefaultAsync(x => x.Name == itemDto.Name) is not null)
        {
            throw new DuplicateTypeNameException(itemDto.Name);
        }

        item.Name = itemDto.Name;
        item.Budget = itemDto.Budget;
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _dbContext.FinTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (item is null)
        {
            throw new NullReferenceException();
        }

        if (item.ListOperations is not null && !item.ListOperations.Any())
        {
            throw new RemoveNotEmptyTypeException();
        }

        item.IsDelete = true;
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<FinOperationDto>> GetOperations(int finTypeId)
    {
        var items = await _dbContext.FinOperations.Where(x => x.FinTypeId == finTypeId).ToListAsync();

        var itemDtos = _mapper.Map<IEnumerable<FinOperationDto>>(items);

        return itemDtos;
    }
}