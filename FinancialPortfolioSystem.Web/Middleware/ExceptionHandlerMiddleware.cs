using FinancialPortfolioSystem.Application.Exceptions;
using FinancialPortfolioSystem.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace FinancialPortfolioSystem.Web.Middleware;

internal class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
        => _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;

        var result = string.Empty;

        switch (exception)
        {
            case ModelValidationException modelValidationException:
                code = HttpStatusCode.BadRequest;
                result = SerializeObject(new
                {
                    ValidationDetails = true,
                    modelValidationException.Errors
                });
                break;
            case NullReferenceException _:
                code = HttpStatusCode.BadRequest;
                result = SerializeObject(new[] { "Invalid request." });
                break;

            case BaseDomainException:
                code = HttpStatusCode.BadRequest;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        if (string.IsNullOrEmpty(result))
        {
            var error = exception.Message;

            if (exception is BaseDomainException baseDomainException)
            {
                error = baseDomainException.Error;
            }

            result = SerializeObject(new[] { error });
        }

        return context.Response.WriteAsync(result);
    }

    private static string SerializeObject(object obj)
        => JsonConvert.SerializeObject(obj, new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(true, true)
            }
        });
}
