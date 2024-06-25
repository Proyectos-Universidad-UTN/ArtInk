using ArtInk.Infraestructure.Repository.Implementations;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Configuration;

public static class Configuration
{
    public static void ConfigureInfraestructure(this IServiceCollection services)
    {
        services.AddTransient<IRepositoryUsuario, RepositoryUsuario>();
        services.AddTransient<IRepositoryProducto, RepositoryProducto>();
        services.AddTransient<IRepositoryRol, RepositoryRol>();
        services.AddTransient<IRepositoryFactura, RepositoryFactura>();
        services.AddTransient<IRepositoryDetalleFactura, RepositoryDetalleFactura>();
        services.AddTransient<IRepositorySucursal, RepositorySucursal>();
        services.AddTransient<IRepositoryReserva, RepositoryReserva>();
        services.AddTransient<IRepositoryServicio, RepositoryServicio>();
        services.AddTransient<IRepositoryHorario, RepositoryHorario>();
        services.AddTransient<IRepositoryReservaPregunta, RepositoryReservaPregunta>();
        services.AddTransient<IRepositoryTipoServicio, RepositoryTipoServicio>();
    }
}
// es una extencion xq usa la palabra this
// Trasient cambia por cada request //scoped como para  factruas y// singleton presente hasta la vida util de la aplicacion