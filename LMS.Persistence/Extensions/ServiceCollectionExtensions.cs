using LMS.Application.Interfaces;
using LMS.Application.Interfaces.Commerce;
using LMS.Application.Interfaces.Courses;
using LMS.Persistence.Context;
using LMS.Persistence.Services;
using LMS.Persistence.Services.Commerce;
using LMS.Persistence.Services.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));
        // Marketplace Services
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IInstructorService, InstructorService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ICourseCategoryService, CourseCategoryService>();
        services.AddScoped<ICourseSubCategoryService, CourseSubCategoryService>();
        services.AddScoped<ICourseLevelService, CourseLevelService>();
        services.AddScoped<ICourseLanguageService, CourseLanguageService>();
        // ======================================================
        // SHOPPING CART SERVICES
        // ======================================================
        services.AddScoped<IShoppingCartService, ShoppingCartService>();
        services.AddScoped<IShoppingCartItemService, ShoppingCartItemService>();

// ======================================================
// ORDER SERVICES
// ======================================================
      services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();

        return services;
    }
}
