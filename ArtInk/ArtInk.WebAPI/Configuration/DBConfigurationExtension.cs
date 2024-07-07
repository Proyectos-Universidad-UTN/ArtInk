using ArtInk.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.WebAPI.Configuration;

public static class DBConfigurationExtension
{
    public static void ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services); //excepciones si no hay servicio 

        services.AddDbContext<ArtInkContext>(options => options.UseSqlServer(configuration.GetConnectionString("ArtInkDataBase"),
             sqlServerOption =>
             {
                 sqlServerOption.EnableRetryOnFailure(); //si se desconecta volver a intentar 
             })
        );
    }
}
