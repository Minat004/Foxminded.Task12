using FinancialTime.Core.DTOs.FinOperation;
using FinancialTime.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTime.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinOperationController : ControllerBase
{
    private readonly IOperationService _operationService;

    public FinOperationController(IOperationService operationService)
    {
        _operationService = operationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FinOperationDto>>> GetOperationsAsync()
    {
        var items = await _operationService.GetAllAsync();

        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FinOperationDto>> GetOperationByIdAsync([FromRoute] int id)
    {
        var item = await _operationService.GetByIdAsync(id);
        
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<FinOperationAddDto>> AddOperationAsync([FromBody] FinOperationAddDto itemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await _operationService.AddAsync(itemDto);

        return Ok(itemDto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditOperationAsync([FromRoute] int id, [FromBody] FinOperationEditDto itemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await _operationService.EditAsync(id, itemDto);

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOperationAsync([FromRoute] int id)
    {
        await _operationService.DeleteAsync(id);

        return Ok();
    }
}