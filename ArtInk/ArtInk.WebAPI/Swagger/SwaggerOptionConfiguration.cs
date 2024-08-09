using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArtInk.WebAPI.Swagger;

public class SwaggerOptionConfiguration(IApiVersionDescriptionProvider apiVersionDescriptionProvider) : IConfigureNamedOptions<SwaggerGenOptions>
{
    public void Configure(string? name, SwaggerGenOptions options) => Configure(options);

    public void Configure(SwaggerGenOptions options)
    {
        if (options == null) return;

        foreach (var apiDescription in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(apiDescription.GroupName, CreateVersionInfo(apiDescription));
        }
    }

    private static OpenApiInfo CreateVersionInfo(ApiVersionDescription apiVersionDescription)
    {
        if (apiVersionDescription == null) return new OpenApiInfo();

        var info = new OpenApiInfo
        {
            Version = apiVersionDescription.ApiVersion.ToString(),
            Title = "ArtInk WebAPI",
            Description = "List of APIs to handle operations for the ArtInk Web API application",
            Contact = new OpenApiContact
            {
                Name = "NOT DEFINED YET",
                Email = "PENDING"
            }
        };

        if(apiVersionDescription.IsDeprecated)
        {
            info.Description += "This API version has been deprecated. Please use one of the new APIs available from the explorer";
        }

        return info;
    }
}