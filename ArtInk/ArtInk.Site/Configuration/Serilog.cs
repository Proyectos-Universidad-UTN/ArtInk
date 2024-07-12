using System.Text;
using Serilog;
using Serilog.Events;

namespace ArtInk.Site.Configuration;

/// <summary>
/// El método ConfigureSerilog configura el registro de eventos (logging) en una aplicaci�n web 
/// utilizando la biblioteca Serilog. Esta configuraci�n incluye diversos niveles de registro, 
/// donde los eventos se env�an tanto a la consola como a archivos de log espec�ficos 
/// seg�n el nivel del evento.
/// </summary>

public static class Serilog
{
    public static void ConfigureSerilog(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                        .Enrich.FromLogContext()
                        .WriteTo.Console(LogEventLevel.Information)
                        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.File(@"Logs\Info-.log", shared: true, encoding:
                                        Encoding.ASCII, rollingInterval: RollingInterval.Day))
                        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug).WriteTo.File(@"Logs\Debug-.log", shared: true, encoding:
                                        System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
                        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level ==
                                        LogEventLevel.Warning).WriteTo.File(@"Logs\Warning-.log", shared: true, encoding: System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
                        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
                        .WriteTo.File(@"Logs\Error-.log", shared: true, encoding: Encoding.ASCII, rollingInterval: RollingInterval.Day))
                        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal)
                        .WriteTo.File(@"Logs\Fatal-.log", shared: true, encoding: Encoding.ASCII, rollingInterval: RollingInterval.Day))
                    .CreateLogger();
                    
        builder.Host.UseSerilog(logger);
    }
}