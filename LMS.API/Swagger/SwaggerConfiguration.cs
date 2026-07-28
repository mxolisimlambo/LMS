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

            options.SwaggerDoc("instructors", new OpenApiInfo
            {
                Title = "Instructors API",
                Version = "v1"
            });

            options.SwaggerDoc("coursecontent", new OpenApiInfo
            {
                Title = "CourseContent API",
                Version = "v1"
            });
            options.SwaggerDoc("coursereview", new OpenApiInfo
            {
                Title = "CourseReview API",
                Version = "v1"
            });
            options.SwaggerDoc("coursecommerce", new OpenApiInfo
            {
                Title = "CourseCommerce API",
                Version = "v1"
            });
            options.SwaggerDoc("coursemodul", new OpenApiInfo
            {
                Title = "CourseModul API",
                Version = "v1"
            });
            options.SwaggerDoc("courselesson", new OpenApiInfo
            {
                Title = "CourseLesson API",
                Version = "v1"
            });
            options.SwaggerDoc("courselanguage", new OpenApiInfo
            {
                Title = "CourseLanguage API",
                Version = "v1"
            });
            options.SwaggerDoc("courselevel", new OpenApiInfo
            {
                Title = "CourseLevel API",
                Version = "v1"
            });
            options.SwaggerDoc("coursesubcategory", new OpenApiInfo
            {
                Title = "CourseSubCategory API",
                Version = "v1"
            });
            options.SwaggerDoc("coursecategory", new OpenApiInfo
            {
                Title = "CourseCategory API",
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
