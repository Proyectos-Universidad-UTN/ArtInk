using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtInk.Application.Configuration.Authentication;
using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Application.ValueResolvers;
using ArtInk.WebAPI.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace ArtInk.WebAPI.Configuration;

public static class AuthenticationExtension
{
    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var authenticationConfigurationSection = configuration.GetSection("AuthenticationConfiguration");
        ArgumentNullException.ThrowIfNull(authenticationConfigurationSection);

        services.Configure<AuthenticationConfiguration>(authenticationConfigurationSection);
        var authenticationConfiguration = authenticationConfigurationSection.Get<AuthenticationConfiguration>();

        ArgumentNullException.ThrowIfNull(authenticationConfiguration);

        services.AddSingleton(authenticationConfiguration);
        services.AddTransient<IServiceIdentity, ServiceIdentity>();

        var JwtSecretkey = Encoding.ASCII.GetBytes(authenticationConfiguration.JwtSettings_Secret);
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(JwtSecretkey),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };

        services.AddSingleton(tokenValidationParameters);
        
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = tokenValidationParameters;
        });

        services.AddTransient<CurrentUserIdResolverAdd>();
        services.AddTransient<CurrentUserIdResolverModify>();
        services.AddTransient<CurrentUserIdResolverBaseEntityAdd>();
        services.AddTransient<CurrentUserIdResolverBaseEntityModify>();
        services.AddScoped<IAuthorizationHandler, UserIdentityHandler>();
    }
}