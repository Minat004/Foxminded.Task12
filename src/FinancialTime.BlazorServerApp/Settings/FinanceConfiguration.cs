namespace FinancialTime.BlazorServerApp.Settings;

public class FinanceConfiguration
{
    public static readonly string Configuration = "FinanceConfiguration";

    public string? BaseUrl { get; set; }
    
    public string? FinOperation { get; set; }
    
    public string? FinType { get; set; }
    
    public string? Report { get; set; }
}