using Microsoft.Extensions.DependencyInjection;

namespace LMS.Application.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        return services;
    }
}
