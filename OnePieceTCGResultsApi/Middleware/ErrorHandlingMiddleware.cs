using System.Net;
using OnePieceTCGResultsApi.Exceptions;
using OnePieceTCGResultsApi.Models;

namespace OnePieceTCGResultsApi.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (BadRequestException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
        }
        catch (NotFoundException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound);
        }
        catch (ServiceUnavailableException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.ServiceUnavailable);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode code)
    {
        context.Response.StatusCode = (int)code;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = ex.Message
        }.ToString());
    }
}