using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LMS.Identity.Data;
using LMS.Identity.Models;
using LMS.Shared.DTOs.Auth;
using LMS.Shared.JWT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LMS.Identity.Services;

public class JwtTokenService
{
    private readonly JwtSettings _jwtSettings;
    private readonly ApplicationIdentityDbContext _context;

    public JwtTokenService(
        IOptions<JwtSettings> jwtSettings,
        ApplicationIdentityDbContext context)
    {
        _jwtSettings = jwtSettings.Value;
        _context = context;
    }

    public async Task<JwtTokenDto> GenerateTokenAsync(
        ApplicationUser user,
        IList<string> roles)
    {
        var permissions =
            await
            (
                from rp in _context.RolePermissions
                join role in _context.Roles
                    on rp.RoleId equals role.Id
                join permission in _context.Permissions
                    on rp.PermissionId equals permission.Id
                where roles.Contains(role.Name!)
                select permission.Name
            )
            .Distinct()
            .ToListAsync();

        var claims = new List<Claim>
        {
            new Claim(
                JwtRegisteredClaimNames.Sub,
                user.Id),

            new Claim(
                JwtRegisteredClaimNames.Email,
                user.Email ?? string.Empty),

            new Claim(
                JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
        };

        foreach (var role in roles)
        {
            claims.Add(
                new Claim(
                    ClaimTypes.Role,
                    role));
        }

        foreach (var permission in permissions)
        {
            claims.Add(
                new Claim(
                    "Permission",
                    permission));
        }

        var expires =
            DateTime.UtcNow.AddMinutes(
                _jwtSettings.ExpiryInMinutes);

        var key =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _jwtSettings.SecretKey));

        var credentials =
            new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

        var token =
            new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials);

        return new JwtTokenDto
        {
            AccessToken =
                new JwtSecurityTokenHandler()
                    .WriteToken(token),

            RefreshToken =
                Guid.NewGuid().ToString("N"),

            Expires =
                expires,

            Permissions =
                permissions
        };
    }
}