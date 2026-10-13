using TaskFlow.WebApi.Middlewares;

namespace TaskFlow.WebApi.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
