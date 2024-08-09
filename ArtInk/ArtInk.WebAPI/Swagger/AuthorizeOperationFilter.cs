using System.Reflection;
using ArtInk.WebAPI.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArtInk.WebAPI.Swagger;

public class AuthorizeOperationFilter : IOperationFilter
{
    private static OpenApiSecurityScheme BearerSchema = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme, Id = "Bearer"}
    };

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var authorizeAttributeOnMethod = context.MethodInfo.GetCustomAttributes<ArtInkAuthorizeAttribute>().Any();
        var authorizeAttributeOnClass = context.MethodInfo.DeclaringType?.GetCustomAttributes<ArtInkAuthorizeAttribute>().Any() ?? false;
        var authorizeAttributeOnParentClass = context.MethodInfo.DeclaringType?.BaseType?.GetCustomAttributes<ArtInkAuthorizeAttribute>().Any() ?? false;
        var allowAnonymusOnMethod = context.MethodInfo.GetCustomAttributes<AllowAnonymousAttribute>() != null;

        if(authorizeAttributeOnMethod || ((authorizeAttributeOnClass || authorizeAttributeOnParentClass) && !allowAnonymusOnMethod))
        {
            operation.Responses.Add(StatusCodes.Status401Unauthorized.ToString(), new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.Add(StatusCodes.Status403Forbidden.ToString(), new OpenApiResponse { Description = "Forbidden" });

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [BearerSchema] = new List<string> { "Bearer" }
                }
            };
        }
    }
}