using AutoMapper;
using FinancialTime.Core.Interfaces;
using FinancialTime.Core.Models;
using FinancialTime.WebAPI.DTOs.FinType;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTime.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinTypeController : ControllerBase
{
    private readonly ITypeService _typeService;
    private readonly IMapper _mapper;

    public FinTypeController(ITypeService typeService, IMapper mapper)
    {
        _typeService = typeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FinTypeDto>>> GetTypesAsync()
    {
        var items = await _typeService.GetAllAsync();
        
        foreach (var item in items)
        {
            item.ListOperations = new List<FinOperation>(await _typeService.GetOperations(item));
        }

        var finTypeList = _mapper.Map<IEnumerable<FinTypeDto>>(items);

        return Ok(finTypeList);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FinTypeDto>> GetTypeByIdAsync(int id)
    {
        var item = await _typeService.GetByIdAsync(id);
        item.ListOperations = new List<FinOperation>(await _typeService.GetOperations(item));
    
        var finType = _mapper.Map<FinTypeDto>(item);

        return Ok(finType);
    }

    [HttpPost]
    public async Task<ActionResult<FinTypeAddDto>> AddTypeAsync([FromBody] FinTypeAddDto itemDto)
    {
        var item = _mapper.Map<FinType>(itemDto);

        await _typeService.AddAsync(item);

        return Ok(itemDto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditTypeAsync(int id, [FromBody] FinTypeEditDto itemDto)
    {
        var newItem = _mapper.Map<FinType>(itemDto);
        newItem.Id = id;

        await _typeService.EditAsync(newItem);

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTypeAsync(int id)
    {
        var item = await _typeService.GetByIdAsync(id);

        await _typeService.DeleteAsync(item);

        return Ok();
    }
}