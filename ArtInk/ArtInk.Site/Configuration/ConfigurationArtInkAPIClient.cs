using ArtInk.Site.Client;

namespace ArtInk.Site.Configuration
{
    public static class ConfigurationArtInkAPIClient
    {
        public static void ConfigureArtInkAPIClient(this IServiceCollection services)
        {
            services.AddSingleton<IAPIArtInkClient, APIArtInkClient>(); // nunca va a cambiar 
        }
       
    }
}
