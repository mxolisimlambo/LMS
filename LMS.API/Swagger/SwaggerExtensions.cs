namespace LMS.API.Swagger;

public static class SwaggerExtensions
{
    public static WebApplication UseSwaggerDocumentation(
        this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint(
                "/swagger/identity/swagger.json",
                "Identity API");

            options.SwaggerEndpoint(
                "/swagger/students/swagger.json",
                "Student API");

            options.SwaggerEndpoint(
                "/swagger/courses/swagger.json",
                "Course API");

            options.SwaggerEndpoint(
                "/swagger/payments/swagger.json",
                "Payment API");
        });

        return app;
    }
}
