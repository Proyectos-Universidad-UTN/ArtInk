using System.Reflection;
using Asp.Versioning.ApiExplorer;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
namespace ArtInk.WebAPI.Swagger;

public static class SwaggerConfiguration
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        
        services.AddFluentValidationRulesToSwagger();

        services.AddSwaggerGen(opts =>
        {
            opts.CustomSchemaIds(type => type.ToString());
            opts.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using Bearer schema",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            opts.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });

            opts.OperationFilter<AuthorizeOperationFilter>();

            opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
        });

        services.AddSwaggerGenNewtonsoftSupport();

        services.ConfigureOptions<SwaggerOptionConfiguration>();
    }

    public static void LoadSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(opts =>
        {
            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            var groupNames = from description in apiVersionDescriptionProvider.ApiVersionDescriptions
                            select description.GroupName;
            
            foreach (var groupName in groupNames)
            {
                opts.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName.ToUpperInvariant());
            }
        });
    }
}