using AutoMapper;
using FinancialTime.Core.DTOs.Report;
using FinancialTime.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTime.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;
    private readonly IMapper _mapper;

    public ReportController(IReportService reportService, IMapper mapper)
    {
        _reportService = reportService;
        _mapper = mapper;
    }

    [HttpGet("{date}")]
    public async Task<ActionResult<ReportDateDto>> GetForDateAsync([FromRoute] string date)
    {
        var dateTime = DateTime.Parse(date);

        var report = await _reportService.GetDateReport(dateTime);

        if (!report.Operations!.Any())
        {
            return NotFound(date);
        }
        
        var reportDto = _mapper.Map<ReportDateDto>(report);
        
        return Ok(reportDto);
    }

    [HttpGet("{startDate}/{endDate}")]
    public async Task<ActionResult<ReportPeriodDto>> GetForPeriodAsync(
        [FromRoute] string startDate, 
        [FromRoute] string endDate)
    {
        var startDateTime = DateTime.Parse(startDate);
        var endDateTime = DateTime.Parse(endDate);
        
        var report = await _reportService.GetPeriodReport(startDateTime, endDateTime);
        
        if (!report.Operations!.Any())
        {
            return NotFound($"{startDate} - {endDate}");
        }
        
        var reportDto = _mapper.Map<ReportPeriodDto>(report);

        return Ok(reportDto);
    }
}