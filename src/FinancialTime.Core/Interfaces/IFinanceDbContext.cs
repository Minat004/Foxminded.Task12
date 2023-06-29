using FinancialTime.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialTime.Core.Interfaces;

public interface IFinanceDbContext
{
    public DbSet<FinType> FinTypes { get; set; }
    
    public DbSet<FinOperation> FinOperations { get; set; }

    public Task<int> SaveChangesAsync();
}