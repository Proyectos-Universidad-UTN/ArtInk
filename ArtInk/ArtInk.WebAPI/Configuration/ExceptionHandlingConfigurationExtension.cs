using System.ComponentModel.DataAnnotations;
using System.Net;
using ArtInk.Application.Comunes;
using Microsoft.AspNetCore.Diagnostics;

namespace ArtInk.WebAPI.Configuration;

public static class ExceptionHandlingConfigurationExtension
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFailure = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFailure != null)
                {
                    var errorDetails = GetErrorDetails(contextFailure);
                    context.Response.StatusCode = errorDetails.StatusCode;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorDetails.ToString());
                }
            });
        });
    }

    private static ErrorDetailsArtInk GetErrorDetails(IExceptionHandlerFeature exception)
    {
        HttpStatusCode httpStatusCode;
        LogLevel logLevel;
        switch (exception.Error)
        {
            case NotFoundException e:
                httpStatusCode = e.HttpStatusCode;
                logLevel = e.LogLevel;
                break;
            case ValidationException:
            case FluentValidation.ValidationException:
            case ValidationEntityException:
                httpStatusCode = HttpStatusCode.UnprocessableEntity;
                logLevel = LogLevel.Information;
                break;
            default:
                httpStatusCode = HttpStatusCode.InternalServerError;
                logLevel = LogLevel.Error;
                break;
        }

        var errorDetails = new ErrorDetailsArtInk()
        {
            Type = exception.Error.GetType().Name,
            StatusCode = (int)httpStatusCode,
            Mensaje = ErrorHandling.ObtenerMensajeExcepcion(exception.Error),
            Detalle = exception.Error.StackTrace,
            LogLevel = logLevel
        };

        return errorDetails;
    }
}