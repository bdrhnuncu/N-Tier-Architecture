using Serilog;
using ILogger = Serilog.ILogger;

namespace Kirala.com.WebAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionMiddleware
    {
        ILogger _logger;
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next,ILogger logger)
        {
            _logger = logger;
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            try
            {
                return _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                throw;
            }

        }

    }
}
