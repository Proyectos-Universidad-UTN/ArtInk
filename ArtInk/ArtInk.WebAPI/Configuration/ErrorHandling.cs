using System.Text;

namespace ArtInk.WebAPI.Configuration;

public static class ErrorHandling
{
    public static string? ObtenerMensajeExcepcion(Exception excepcion)
    {
        if (excepcion == null) return null;

        var mensajeError = new StringBuilder();
        mensajeError.Append(excepcion.Message);
        return excepcion.InnerException != null ? ObtenerMensajesCompletosExcepcion(excepcion) : mensajeError.ToString();
    }

    private static string ObtenerMensajesCompletosExcepcion(Exception excepcion)
    {
        if(excepcion.InnerException == null) return excepcion.Message;

        return $"{excepcion.Message} : {ObtenerMensajesCompletosExcepcion(excepcion.InnerException)}";
    }
}