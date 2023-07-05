using FinancialTime.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialTime.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<FinanceDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("FinanceConnection"));
        });

        services.AddScoped<IFinanceDbContext>(provider => provider.GetService<FinanceDbContext>()!);
    }
}