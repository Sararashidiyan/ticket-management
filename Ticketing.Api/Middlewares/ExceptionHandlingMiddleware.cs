using System.Net;
using Ticketing.Core.Exceptions;

namespace Ticketing.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (Exception ex)
            {
                if (ex is CustomException)//Handled exceptions
                {
                    var exception = (CustomException)ex;
                    _logger.LogError(exception, exception.Message);
                    context.Response.StatusCode = exception.StatusCode;
                    await context.Response.WriteAsJsonAsync(new { error = exception.Message });
                }
                else//Unhandled exceptions
                {
                    _logger.LogError(ex, "Unhandled exception occurred");
                    context.Response.StatusCode =Convert.ToInt16(HttpStatusCode.InternalServerError);
                    await context.Response.WriteAsJsonAsync(new { error = ex.Message });
                }
            }
        }
    }
}
