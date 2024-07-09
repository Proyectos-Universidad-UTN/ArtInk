using ArtInk.Application.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ArtInk.WebAPI.Configuration;

public static class FluentValidationConfiguration
{
    public static void ConfigureFluentValidation(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddValidatorsFromAssemblyContaining<SucursalValidator>();

        services.AddValidatorsFromAssemblyContaining<ServicioValidator>();

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
    }
}