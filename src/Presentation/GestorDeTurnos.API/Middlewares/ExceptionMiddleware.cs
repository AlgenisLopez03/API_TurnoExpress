using GestorDeTurnos.Application.Exceptions;
using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Application.Wrappers;
using Serilog.Context;

namespace GestorDeTurnos.API.Middlewares
{
    /// <summary>
    /// Middleware for handling exceptions globally in the application.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        /// <param name="logger">The logger for logging information.</param>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="context">The HTTP context for the current request.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context)
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

        private async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            var exception = e.InnerException ?? e;
            context.Response.ContentType = "application/json";
            string message = exception.Message;

            switch (exception)
            {
                case BadRequestException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;

                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var userName = context.GetUserName();
            LogContext.PushProperty(nameof(userName), userName);
            _logger.LogError(e, message);

            var response = new ApiResponse(context.Response.StatusCode, message);
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}