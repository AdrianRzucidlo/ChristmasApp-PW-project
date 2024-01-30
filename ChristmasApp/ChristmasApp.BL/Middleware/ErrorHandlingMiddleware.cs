using Microsoft.AspNetCore.Http;

namespace Rzucidlo.ChristmasApp.BL.Middleware;

public sealed class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An error occured, try again.");
        }
    }
}