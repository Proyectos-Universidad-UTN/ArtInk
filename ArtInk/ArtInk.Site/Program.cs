
using Serilog.Events;
using Serilog;
using System.Text;
using ArtInk.web.Middleware;
using ArtInk.Site.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureArtInkAPIClient();



//Configuraci�n Serilog
// Logger. P.E. Verbose = muestra SQl Statement
var logger = new LoggerConfiguration()
     // Limitar la informaci�n de depuraci�n
     .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
    .Enrich.FromLogContext()
    // Log LogEventLevel.Verbose muestra mucha informaci�n, pero no es necesaria solo para el proceso de depuraci�n
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.File(@"Logs\Info-.log", shared: true, encoding:
    Encoding.ASCII, rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug).WriteTo.File(@"Logs\Debug-.log", shared: true, encoding:
    System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level ==
    LogEventLevel.Warning).WriteTo.File(@"Logs\Warning-.log", shared: true, encoding:
    System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
     .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level ==
    LogEventLevel.Error).WriteTo.File(@"Logs\Error-.log", shared: true, encoding:
    Encoding.ASCII, rollingInterval: RollingInterval.Day))
     .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level ==
    LogEventLevel.Fatal).WriteTo.File(@"Logs\Fatal-.log", shared: true, encoding:
    Encoding.ASCII, rollingInterval: RollingInterval.Day))
     .CreateLogger();
builder.Host.UseSerilog(logger);

builder.Services.ConfigureSiteAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

else
{
    // Error control Middleware

    app.UseMiddleware<ErrorHandlingMiddleware>();
}

//Activar soporte a la solicitud de registro SERILOG
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Activar Antiforgery
app.UseAntiforgery();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
