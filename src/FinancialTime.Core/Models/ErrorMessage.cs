using System.Net;

namespace FinancialTime.Core.Models;

public class ErrorMessage
{
    public HttpStatusCode StatusCode { get; set; }
    
    public string? Error { get; set; }

    public string? StackTrace { get; set; }
}