using LMS.API.Middleware;

namespace LMS.API.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder
        UseGlobalExceptionMiddleware(
            this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionMiddleware>();
    }
}