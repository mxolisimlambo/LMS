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
                "/swagger/instructors/swagger.json",
                "Instructor API");

            options.SwaggerEndpoint(
           "/swagger/instructors/swagger.json",
           "Instructor API");

            options.SwaggerEndpoint(
                "/swagger/coursecontent/swagger.json",
                "CourseContent API");

            options.SwaggerEndpoint(
                "/swagger/coursereview/swagger.json",
                "CourseReview API");

            options.SwaggerEndpoint(
                "/swagger/coursecommerce/swagger.json",
                "CourseCommerce API");

            options.SwaggerEndpoint(
                "/swagger/coursemodul/swagger.json",
                "CourseModul API");

            options.SwaggerEndpoint(
                "/swagger/courselesson/swagger.json",
                "CourseLesson API");

            options.SwaggerEndpoint(
          "/swagger/courselanguage/swagger.json",
          "CourseLanguage API");

            options.SwaggerEndpoint(
          "/swagger/courselevel/swagger.json",
          "CourseLevel API");

            options.SwaggerEndpoint(
          "/swagger/coursesubcategory/swagger.json",
          "CourseSubCategory API");

            options.SwaggerEndpoint(
          "/swagger/coursecategory/swagger.json",
          "CourseCategory API");

        });



        return app;
    }
}
