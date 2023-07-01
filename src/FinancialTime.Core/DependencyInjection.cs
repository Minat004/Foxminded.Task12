using FinancialTime.Core.Interfaces;
using FinancialTime.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialTime.Core;

public static class DependencyInjection
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddScoped<IOperationService, OperationService>();
        services.AddScoped<ITypeService, TypeService>();
    }
}