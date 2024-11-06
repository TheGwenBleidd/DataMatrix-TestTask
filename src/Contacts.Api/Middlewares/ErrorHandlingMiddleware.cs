using Contacts.Application.Helpers.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Contacts.Api.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError("An unhandled exception occurred. {Message} {@Exception} {Method}", exception.Message, exception, context.Request.Method);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (exception is ValidationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            if (exception is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            var result = new ObjectResult(new { errors = new Dictionary<string, string> { ["message"] = exception.Message } })
            {
                StatusCode = context.Response.StatusCode
            };

            await result.ExecuteResultAsync(new ActionContext { HttpContext = context });
        }
    }
}