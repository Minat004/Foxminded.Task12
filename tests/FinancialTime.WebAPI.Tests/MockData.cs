using FinancialTime.Core.Enums;
using FinancialTime.Core.Models;
using FinancialTime.WebAPI.DTOs.FinOperation;

namespace FinancialTime.WebAPI.Tests;

public static class MockData
{
    public static IEnumerable<FinOperation> GetOperations()
    {
        var result = new List<FinOperation>
        {
            new()
            {
                Id = 1,
                Value = 4000.12M,
                Date = new DateTime(2023, 6, 10),
                FinTypeId = 1,
                FinType = new FinType
                {
                    Id = 1,
                    Budget = EBudget.Income,
                    Name = "Salary"
                }
            },
            new()
            {
                Id = 2,
                Value = 1000.5M,
                Date = new DateTime(2023, 6, 10),
                FinTypeId = 2,
                FinType = new FinType
                {
                    Id = 2,
                    Budget = EBudget.Expense,
                    Name = "Products"
                }
            },
            new()
            {
                Id = 3,
                Value = 133M,
                Date = new DateTime(2023, 6, 10),
                FinTypeId = 3,
                FinType = new FinType
                {
                    Id = 3,
                    Budget = EBudget.Expense,
                    Name = "Fun"
                }
            },
            new()
            {
                Id = 4,
                Value = 100M,
                Date = new DateTime(2023, 6, 10),
                FinTypeId = 4,
                FinType = new FinType
                {
                    Id = 4,
                    Budget = EBudget.Expense,
                    Name = "Restaurants"
                }
            },
            new()
            {
                Id = 5,
                Value = 150M,
                Date = new DateTime(2023, 6, 11),
                FinTypeId = 4,
                FinType = new FinType
                {
                    Id = 4,
                    Budget = EBudget.Expense,
                    Name = "Restaurants"
                }
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