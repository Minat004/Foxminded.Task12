using FinancialTime.Core.DTOs.FinOperation;
using FinancialTime.Core.Enums;
using FinancialTime.Core.Models;

namespace FinancialTime.WebAPI.Tests;

public static class MockData
{
    public static IEnumerable<FinOperationDto> GetOperations()
    {
        var result = new List<FinOperationDto>
        {
            new()
            {
                Value = 4000.12M,
                Date = new DateTime(2023, 6, 10),
                FinTypeName = "Salary",
                FinTypeBudget = "Income"
            },
            new()
            {
                Value = 1000.5M,
                Date = new DateTime(2023, 6, 10),
                FinTypeName = "Products",
                FinTypeBudget = "Expense"
            },
            new()
            {
                Value = 133M,
                Date = new DateTime(2023, 6, 10),
                FinTypeName = "Fun",
                FinTypeBudget = "Expense"
            },
            new()
            {
                Value = 100M,
                Date = new DateTime(2023, 6, 10),
                FinTypeName = "Restaurants",
                FinTypeBudget = "Expense"
            },
            new()
            {
                Value = 150M,
                Date = new DateTime(2023, 6, 11),
                FinTypeName = "Restaurants",
                FinTypeBudget = "Expense"
            },
        };

        return result;
    }

    public static FinOperationEditDto GetOperationEditDto()
    {
        return new FinOperationEditDto
        {
            Value = 500,
            Date = DateTime.Today,
            FinTypeId = 4
        };
    }
    
    public static IEnumerable<FinType> GetTypes()
    {
        var result = new List<FinType>()
        {
            new()
            {
                Id = 1,
                Budget = EBudget.Income,
                Name = "Salary"
            },
            new()
            {
                Id = 2,
                Budget = EBudget.Expense,
                Name = "Products"
            },
            new()
            {
                Id = 3,
                Budget = EBudget.Expense,
                Name = "Fun"
            },
            new()
            {
                Id = 4,
                Budget = EBudget.Expense,
                Name = "Restaurants"
            },
        };

        return result;
    }
}