using ArtInk.Application.Profiles;
using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Implementations;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Configuration;

public static class Configuration
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddTransient<IServiceUsuario, ServiceUsuario>();
        services.AddTransient<IServiceProducto, ServiceProducto>();
        services.AddTransient<IServiceRol, ServiceRol>();
        services.AddTransient<IServiceDetalleFactura, ServiceDetalleFactura>();
        services.AddTransient<IServiceFactura, ServiceFactura>();
        services.AddTransient<IServiceSucursal, ServiceSucursal>();
        services.AddTransient<IServiceReserva, ServiceReserva>();
        services.AddTransient<IServiceServicio, ServiceServicio>();
        services.AddTransient<IServiceReservaPregunta, ServiceReservaPregunta>();
        services.AddTransient<IServiceUnidadMedida, ServiceUnidadMedida>();
        services.AddTransient<IServiceCategoria, ServiceCategoria>();
        services.AddTransient<IServiceHorario, ServiceHorario>();
        services.AddTransient<IServiceTipoServicio, ServiceTipoServicio>();
        services.AddTransient<IServiceProvincia, ServiceProvincia>();
        services.AddTransient<IServiceCanton, ServiceCanton>();
        services.AddTransient<IServiceDistrito, ServiceDistrito>();
        services.AddTransient<IServiceFeriado, ServiceFeriado>();
        services.AddTransient<IServiceSucursalFeriado, ServiceSucursalFeriado>();
        services.AddTransient<IServiceSucursalHorario, ServiceSucursalHorario>();
        services.AddTransient<IServiceSucursalHorarioBloqueo, ServiceSucursalHorarioBloqueo>();
        services.AddTransient<IServiceInventario, ServiceInventario>();
    }
    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<ModelToDtoApplicationProfile>();
            config.AddProfile<DtoToModelApplicationProfile>();
        });
    }
}
