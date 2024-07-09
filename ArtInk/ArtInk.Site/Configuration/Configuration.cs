using ArtInk.Site.Profiles;

namespace ArtInk.Site.Configuration;

public static class Configuration
{
    public static void ConfigureSiteAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<ResponseDTOToRequestDTOApplicationProfile>();
        });
    }
}