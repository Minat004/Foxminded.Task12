using FinancialTime.Core.Interfaces;
using FinancialTime.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialTime.Infrastructure;

public class FinanceDbContext : DbContext, IFinanceDbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
    {
    }

    public DbSet<FinType> FinTypes { get; set; } = null!;
    
    public DbSet<FinOperation> FinOperations { get; set; } = null!;
    
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Seed();
    }
}