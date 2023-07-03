using AutoMapper;
using FinancialTime.Core.Interfaces;
using FinancialTime.Core.Models;
using FinancialTime.WebAPI.Controllers;
using FinancialTime.WebAPI.DTOs.FinOperation;
using FinancialTime.WebAPI.Mappers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FinancialTime.WebAPI.Tests.Controllers;

public class FinOperationControllerTests
{
    private readonly MapperConfiguration _mockOperationMapper;

    public FinOperationControllerTests()
    {
        _mockOperationMapper = new MapperConfiguration(config =>
            config.AddProfile(new FinOperationProfile()));
    }

    [Fact]
    public async Task GetOperationsOkResultTest()
    {
        // Arrange
        var mockOperationService = new Mock<IOperationService>();
        mockOperationService
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(MockData.GetOperations());
        
        var controller = new FinOperationController(mockOperationService.Object, _mockOperationMapper.CreateMapper());

        // Act
        var actionResult = await controller.GetOperationsAsync();
        var result = actionResult.Result as OkObjectResult;
        var resultValue = result!.Value as IEnumerable<FinOperationDto>;

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(200);
        resultValue.Should().HaveCount(5);
    }
    
    [Fact]
    public async Task GetOperationsNoContentResultTest()
    {
        // Arrange
        var mockOperationService = new Mock<IOperationService>();
        mockOperationService
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(new List<FinOperation>());


        var controller = new FinOperationController(mockOperationService.Object, _mockOperationMapper.CreateMapper());

        // Act
        var actionResult = await controller.GetOperationsAsync();
        var result = actionResult.Result as NoContentResult;

        // Assert
        result!.StatusCode.Should().Be(204);
    }
    
    [Fact]
    public async Task GetOperationByIdOkResultTest()
    {
        // Arrange
        var mockOperationService = new Mock<IOperationService>();
        mockOperationService
            .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(It.IsAny<FinOperation>());


        var controller = new FinOperationController(mockOperationService.Object, _mockOperationMapper.CreateMapper());

        // Act
        var actionResult = await controller.GetOperationByIdAsync(It.IsAny<int>());
        var result = actionResult.Result as OkObjectResult;

        // Assert
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(200);
    }
    
    [Fact]
    public async Task AddOperationOkResultTest()
    {
        // Arrange
        var mockOperationService = new Mock<IOperationService>();

        var controller = new FinOperationController(mockOperationService.Object, _mockOperationMapper.CreateMapper());

        // Act
        var actionResult = await controller.AddOperationAsync(It.IsAny<FinOperationAddDto>());
        var result = actionResult.Result as OkObjectResult;

        // Assert
        mockOperationService.Verify(x => x.AddAsync(It.IsAny<FinOperation>()), Times.Once);
        
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(200);
    }
    
    [Fact]
    public async Task EditOperationOkResultTest()
    {
        // Arrange
        var mockOperationService = new Mock<IOperationService>();

        var controller = new FinOperationController(mockOperationService.Object, _mockOperationMapper.CreateMapper());

        // Act
        var actionResult = await controller.EditOperationAsync(It.IsAny<int>(), MockData.GetOperationEditDto());
        var result = actionResult as OkResult;

        // Assert
        mockOperationService.Verify(x => x.EditAsync(It.IsAny<FinOperation>()), Times.Once);
        
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(200);
    }
    
    [Fact]
    public async Task DeleteOperationOkResultTest()
    {
        // Arrange
        var mockOperationService = new Mock<IOperationService>();

        var controller = new FinOperationController(mockOperationService.Object, _mockOperationMapper.CreateMapper());

        // Act
        var actionResult = await controller.DeleteOperationAsync(It.IsAny<int>());
        var result = actionResult as OkResult;

        // Assert
        mockOperationService.Verify(x => x.DeleteAsync(It.IsAny<FinOperation>()), Times.Once);
        
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(200);
    }
}