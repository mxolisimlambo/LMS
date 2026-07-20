using LMS.Application.Interfaces;
using LMS.Identity.Models;
using LMS.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using LMS.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LMS.Identity.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace LMS.Identity.Extensions;

public static class IdentityServiceRegistration
{
    public static IServiceCollection AddIdentityServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationIdentityDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        });

        services
            .AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IIdentityService, IdentityService>();

        services.AddScoped<IRoleService, RoleService>();

        services.AddScoped<IPermissionService, PermissionService>();

        services.AddScoped<IUserRoleService, UserRoleService>();

        services.AddScoped<JwtTokenService>();

        services.AddSingleton<IAuthorizationPolicyProvider,
            PermissionPolicyProvider>();

        services.AddScoped<IAuthorizationHandler,
            PermissionAuthorizationHandler>();

        return services;
    }
}