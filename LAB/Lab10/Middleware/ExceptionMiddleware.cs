using System.Text.Json;

namespace StudentManagementAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
                _logger.LogError(ex, "Unhandled API error occurred while processing request.");

                if (context.Response.HasStarted)
                    throw;

                context.Response.Clear();
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var payload = new
                {
                    StatusCode = 500,
                    Message = "Unexpected server error occurred",
                    Error = ex.Message
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(payload));
            }
        }
    }
}