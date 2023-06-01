using System.Net;
using Microsoft.AspNetCore.Http;
using Responser.Dtos;
using Responser.Exceptions;

namespace Responser.Middlewares;

public class ExceptionResponseMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BadRequest ex)
        {
            if (!context.Response.HasStarted)
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            if (ex.Code is not null)
                await context.Response.WriteAsJsonAsync(new FailureResponseDto(ex.Code, ex.Message));
            else
                await context.Response.WriteAsJsonAsync(new FailureResponseDto(ex.Message));
        }
        catch (Unauthorized ex)
        {
            if (!context.Response.HasStarted)
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            await context.Response.WriteAsJsonAsync(new FailureResponseDto(ex.Message));
        }
        catch (Exception ex)
        {
            if (!context.Response.HasStarted)
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
            await context.Response.WriteAsJsonAsync(new FailureResponseDto(ex.Message));
        }
    }
}
