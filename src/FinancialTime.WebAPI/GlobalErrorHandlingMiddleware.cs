﻿using System.Net;
using FinancialTime.Core.Exceptions;
using FinancialTime.Core.Models;
using Newtonsoft.Json;

namespace FinancialTime.WebAPI;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status = 0;
        var stackTrace = string.Empty;
        var message = string.Empty;

        Message(exception, ref message, ref status, ref stackTrace);
        
        var exceptionResult = JsonConvert.SerializeObject(
            new ErrorMessage { StatusCode = status, Error = message, StackTrace = stackTrace});
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        await context.Response.WriteAsync(exceptionResult);
    }

    private static void Message(Exception exception, ref string? message, ref HttpStatusCode status, ref string? stackTrace)
    {
        var exceptionType = exception.GetType();
        
        if (exceptionType == typeof(NullReferenceException))
        {
            message = exception.Message;
            status = HttpStatusCode.NotFound;
            stackTrace = exception.StackTrace;
            return;
        }
        
        if (exceptionType == typeof(FormatException))
        {
            message = exception.Message;
            status = HttpStatusCode.BadRequest;
            stackTrace = exception.StackTrace;
            return;
        }
        
        if (exceptionType == typeof(DuplicateTypeNameException))
        {
            message = exception.Message;
            status = HttpStatusCode.Conflict;
            stackTrace = exception.StackTrace;
            return;
        }
        
        if (exceptionType == typeof(RemoveNotEmptyTypeException))
        {
            message = exception.Message;
            status = HttpStatusCode.Conflict;
            stackTrace = exception.StackTrace;
        }
    }
}