using Serilog;
using ArtInk.Site.Configuration;
using ArtInk.Site.Middleware;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization();

builder.Services.ConfigureArtInkAPIClient();

// Configure serilog for errors
builder.ConfigureSerilog();

builder.Services.ConfigureSiteAutoMapper();

builder.Services.ConfigureLocalization();

var app = builder.Build();

var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

else
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.Use(async (ctx, next) =>
       {
           await next();
           if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
           {
               ctx.Request.Path = "/NotFound";
               await next();
           }
       });
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

await app.RunAsync();
