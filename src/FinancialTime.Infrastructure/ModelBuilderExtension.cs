using FinancialTime.Core.Enums;
using FinancialTime.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialTime.Infrastructure;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FinType>().HasData(
            new FinType {Id = 1, Name = "Salary", Budget = EBudget.Income},
            new FinType {Id = 2, Name = "Products", Budget = EBudget.Expense},
            new FinType {Id = 3, Name = "Fun", Budget = EBudget.Expense},
            new FinType {Id = 4, Name = "Restaurants", Budget = EBudget.Expense});

        modelBuilder.Entity<FinOperation>().HasData(
            new FinOperation {Id = 1, Value = 4000, FinTypeId = 1, Date = new DateTime(2023, 6, 10)},
            new FinOperation {Id = 2, Value = 1000, FinTypeId = 2, Date = new DateTime(2023, 6, 10)},
            new FinOperation {Id = 3, Value = 133, FinTypeId = 3, Date = new DateTime(2023, 6, 10)},
            new FinOperation {Id = 4, Value = 100, FinTypeId = 4, Date = new DateTime(2023, 6, 10)},
            new FinOperation {Id = 5, Value = 150, FinTypeId = 4, Date = new DateTime(2023, 6, 11)}
            );
    }
}