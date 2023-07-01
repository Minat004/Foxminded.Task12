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
    public async Task<IEnumerable<FinOperationDto>> GetOperations()
    {
        var items = await _operationService.GetAllAsync();

        var finOperationList = _mapper.Map<IEnumerable<FinOperationDto>>(items);

        return finOperationList;
    }

    [HttpGet("{id:int}")]
    public async Task<FinOperationDto> GetOperationById(int id)
    {
        var item = await _operationService.GetByIdAsync(id);

        var finOperation = _mapper.Map<FinOperationDto>(item);
        
        return finOperation;
    }

    [HttpPost]
    public async Task<ActionResult<FinOperationAddDto>> AddOperation([FromBody] FinOperationAddDto itemDto)
    {
        var item = _mapper.Map<FinOperation>(itemDto);

        await _operationService.AddAsync(item);

        return CreatedAtAction(nameof(AddOperation), new { id = item.Id }, itemDto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditOperation(int id, [FromBody] FinOperationEditDto itemDto)
    {
        var newItem = _mapper.Map<FinOperation>(itemDto);
        newItem.Id = id;

        await _operationService.EditAsync(newItem);

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOperation(int id)
    {
        var item = await _operationService.GetByIdAsync(id);

        await _operationService.DeleteAsync(item);

        return Ok();
    }
}