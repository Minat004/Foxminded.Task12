using AutoMapper;
using FinancialTime.Core.Interfaces;
using FinancialTime.WebAPI.DTOs.Report;
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

    [HttpGet("DateReport")]
    public async Task<ReportDateDto> GetForDate(string date)
    {
        var dateTime = DateTime.Parse(date);

        var report = await _reportService.GetDateReport(dateTime);
        
        var reportDto = _mapper.Map<ReportDateDto>(report);
        
        return reportDto;
    }

    [HttpGet("PeriodReport")]
    public async Task<ReportPeriodDto> GetForPeriod(string startDate, string endDate)
    {
        var startDateTime = DateTime.Parse(startDate);
        var endDateTime = DateTime.Parse(endDate);
        
        var report = await _reportService.GetPeriodReport(startDateTime, endDateTime);
        
        var reportDto = _mapper.Map<ReportPeriodDto>(report);

        return reportDto;
    }
}