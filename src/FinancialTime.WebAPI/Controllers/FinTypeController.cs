using FinancialTime.Core.DTOs.FinType;
using FinancialTime.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTime.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinTypeController : ControllerBase
{
    private readonly ITypeService _typeService;

    public FinTypeController(ITypeService typeService)
    {
        _typeService = typeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FinTypeDto>>> GetTypesAsync()
    {
        var items = await _typeService.GetAllAsync();

        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FinTypeDto>> GetTypeByIdAsync([FromRoute] int id)
    {
        var item = await _typeService.GetByIdAsync(id);

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<FinTypeAddDto>> AddTypeAsync([FromBody] FinTypeAddDto itemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await _typeService.AddAsync(itemDto);

        return Ok(itemDto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditTypeAsync([FromRoute] int id, [FromBody] FinTypeEditDto itemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await _typeService.EditAsync(id, itemDto);

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTypeAsync([FromRoute] int id)
    {
        await _typeService.DeleteAsync(id);

        return Ok();
    }
}