using ArtInk.Site.Client;

namespace ArtInk.Site.Configuration;

public static class ConfigurationArtInkApiClient
{
    public static void ConfigureArtInkAPIClient(this IServiceCollection services)
    {
        services.AddSingleton<IApiArtInkClient, ApiArtInkClient>(); // nunca va a cambiar 
    }
}