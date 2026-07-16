using LMS.Shared.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LMS.Application.Extensions;
using LMS.Identity.Extensions;

var builder = WebApplication.CreateBuilder(args);


// =======================================
// SERVICES
// =======================================


// MVC Controllers
builder.Services.AddControllers();


// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


// JWT Settings
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings")
);


// JWT Authentication
var jwtSettings = builder.Configuration
    .GetSection("JwtSettings")
    .Get<JwtSettings>();


builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme =
            JwtBearerDefaults.AuthenticationScheme;

        options.DefaultChallengeScheme =
            JwtBearerDefaults.AuthenticationScheme;

        options.DefaultScheme =
            JwtBearerDefaults.AuthenticationScheme;
    })

    .AddJwtBearer(options =>
    {
        options.SaveToken = true;

        options.RequireHttpsMetadata = false;


        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,

                ValidateAudience = true,

                ValidateLifetime = true,

                ValidateIssuerSigningKey = true,


                ValidIssuer =
                    jwtSettings!.Issuer,


                ValidAudience =
                    jwtSettings.Audience,


                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            jwtSettings.SecretKey))
            };
    });


// Authorization
builder.Services.AddAuthorization();
builder.Services.AddApplicationServices();

//builder.Services.AddIdentityServices();
builder.Services.AddIdentityServices(builder.Configuration);

// =======================================
// BUILD APPLICATION
// =======================================

var app = builder.Build();



// =======================================
// HTTP PIPELINE
// =======================================


// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


// Authentication MUST come first
app.UseAuthentication();


// Authorization
app.UseAuthorization();


// Map API Controllers
app.MapControllers();



app.Run();