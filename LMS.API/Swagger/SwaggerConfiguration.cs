using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace LMS.API.Swagger;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerDocumentation(
        this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("identity", new OpenApiInfo
            {
                Title = "LMS Identity API",
                Version = "v1"
            });

            options.SwaggerDoc("students", new OpenApiInfo
            {
                Title = "Student API",
                Version = "v1"
            });

            options.SwaggerDoc("courses", new OpenApiInfo
            {
                Title = "Course API",
                Version = "v1"
            });

            options.SwaggerDoc("payments", new OpenApiInfo
            {
                Title = "Payment API",
                Version = "v1"
            });

            options.DocInclusionPredicate((documentName, apiDescription) =>
            {
                return apiDescription.GroupName == documentName;
            });
        });

        return services;
    }
}
