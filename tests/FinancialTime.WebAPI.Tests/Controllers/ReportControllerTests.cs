using AutoMapper;
using FinancialTime.Core.Interfaces;
using FinancialTime.Core.Mappers;
using FinancialTime.Core.Models;
using FinancialTime.Core.ViewModels;
using FinancialTime.WebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FinancialTime.WebAPI.Tests.Controllers;

public class ReportControllerTests
{
    private readonly MapperConfiguration _mockOperationMapper;

    public ReportControllerTests()
    {
        _mockOperationMapper = new MapperConfiguration(config =>
            config.AddProfile(new ReportProfile()));
    }

    [Theory]
    [InlineData("23.06.2023")]
    [InlineData("23/06/2023")]
    [InlineData("23,06,2023")]
    public async Task GetForDateOkResultTest(string date)
    {
        // Arrange
        var mockReportService = new Mock<IReportService>();
        mockReportService
            .Setup(x => x.GetDateReport(It.IsAny<DateTime>()))
            .ReturnsAsync(It.IsAny<ReportViewModel>());
        
        var controller = new ReportController(mockReportService.Object, _mockOperationMapper.CreateMapper());

        // Act
        var actionResult = await controller.GetForDateAsync(date);
        var result = actionResult.Result as OkObjectResult;

        // Assert
        mockReportService.Verify(x => x.GetDateReport(It.IsAny<DateTime>()), Times.Once);
        
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(200);
    }
    
    [Theory]
    [InlineData("1,1,2022", "3,7,2023")]
    public async Task GetForPeriodOkResultTest(string startDate, string endDate)
    {
        // Arrange
        var mockReportService = new Mock<IReportService>();
        mockReportService
            .Setup(x => x.GetPeriodReport(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .ReturnsAsync(It.IsAny<ReportViewModel>());
        
        var controller = new ReportController(mockReportService.Object, _mockOperationMapper.CreateMapper());

        // Act
        var actionResult = await controller.GetForPeriodAsync(startDate, endDate);
        var result = actionResult.Result as OkObjectResult;

        // Assert
        mockReportService.Verify(x => x.GetPeriodReport(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
        
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(200);
    }
}