using ArtInk.Application.Profiles;
using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddTransient<IServicePedido, ServicePedido>();
        services.AddTransient<IServiceReservaServicio, ServiceReservaServicio>();
        services.AddTransient<IServiceCliente, ServiceCliente>();
        services.AddTransient<IServiceTipoPago, ServiceTipoPago>();
        services.AddTransient<IServiceImpuesto, ServiceImpuesto>();
    }

    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<ModelToDtoApplicationProfile>();
            config.AddProfile<DtoToModelApplicationProfile>();
            config.AddProfile<MiscApplicationProfile>();
        });
    }
}