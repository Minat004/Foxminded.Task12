using AutoMapper;
using FinancialTime.Core.Interfaces;
using FinancialTime.Core.Models;
using FinancialTime.WebAPI.DTOs.FinOperation;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTime.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinOperationController : ControllerBase
{
    private readonly IOperationService _operationService;
    private readonly IMapper _mapper;

    public FinOperationController(IOperationService operationService, IMapper mapper)
    {
        _operationService = operationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FinOperationDto>>> GetOperationsAsync()
    {
        var items = await _operationService.GetAllAsync();

        if (!items.Any())
        {
            return NoContent();
        }

        var finOperationList = _mapper.Map<IEnumerable<FinOperationDto>>(items);

        return Ok(finOperationList);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FinOperationDto>> GetOperationByIdAsync(int id)
    {
        var item = await _operationService.GetByIdAsync(id);

        var finOperation = _mapper.Map<FinOperationDto>(item);
        
        return Ok(finOperation);
    }

    [HttpPost]
    public async Task<ActionResult<FinOperationAddDto>> AddOperationAsync([FromBody] FinOperationAddDto itemDto)
    {
        var item = _mapper.Map<FinOperation>(itemDto);

        await _operationService.AddAsync(item);

        return Ok(itemDto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditOperationAsync(int id, [FromBody] FinOperationEditDto itemDto)
    {
        var newItem = _mapper.Map<FinOperation>(itemDto);
        newItem.Id = id;

        await _operationService.EditAsync(newItem);

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOperationAsync(int id)
    {
        var item = await _operationService.GetByIdAsync(id);

        await _operationService.DeleteAsync(item);

        return Ok();
    }
}