using LMS.Persistence.Context;
using LMS.Application.Interfaces;
using LMS.Persistence.Services;
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
        services.AddScoped<IInstructorService,InstructorService>();

        return services;
    }
}
