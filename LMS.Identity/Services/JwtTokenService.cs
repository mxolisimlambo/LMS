using LMS.Identity.Models;
using LMS.Shared.JWT;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LMS.Identity.Services;

public class JwtTokenService
{
    private readonly JwtSettings _jwtSettings;


    public JwtTokenService(
        IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }


    public string GenerateToken(
        ApplicationUser user,
        IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(
                JwtRegisteredClaimNames.Sub,
                user.Id),

            new Claim(
                JwtRegisteredClaimNames.Email,
                user.Email ?? ""),

            new Claim(
                JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
        };


        foreach(var role in roles)
        {
            claims.Add(
                new Claim(
                    ClaimTypes.Role,
                    role));
        }


        var key = new SymmetricSecurityKey(
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

                expires: DateTime.UtcNow.AddMinutes(
                    _jwtSettings.ExpiryInMinutes),

                signingCredentials: credentials
            );


        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}