using LMS.Application.Interfaces;
using LMS.Identity.Data;
using LMS.Identity.Models;
using LMS.Identity.Permissions;
using LMS.Shared.DTOs.Permissions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMS.Identity.Services;

public class PermissionService : IPermissionService
{
    private readonly ApplicationIdentityDbContext _context;

    private readonly RoleManager<ApplicationRole> _roleManager;

    public PermissionService(
        ApplicationIdentityDbContext context,
        RoleManager<ApplicationRole> roleManager)
    {
        _context = context;
        _roleManager = roleManager;
    }

}