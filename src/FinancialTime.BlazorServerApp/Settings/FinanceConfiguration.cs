namespace FinancialTime.BlazorServerApp.Settings;

public class FinanceConfiguration
{
    public static readonly string Configuration = "FinanceConfiguration";
    
    public string? OperationUrl { get; set; }
    
    public string? TypeUrl { get; set; }
    
    public string? ReportUrl { get; set; }
}