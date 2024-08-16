using System.Globalization;

namespace ArtInk.Utils;

public static class ManejoFechaHora
{
    public static List<TimeOnly> ObtenerHoras(TimeOnly inicio, TimeOnly fin ) 
    {
        List<TimeOnly> horas = new List<TimeOnly>();

        TimeOnly tiempoActual = inicio;

        while (tiempoActual <= fin)
        {
            horas.Add(tiempoActual);

            tiempoActual = tiempoActual.AddHours(1);
        }

        return horas;
    }

    public static List<DateOnly> ObtenerDias(DateOnly inicio, DateOnly fin ) 
    {
        List<DateOnly> dias = new List<DateOnly>();

        DateOnly diaActual = inicio;

        while (diaActual <= fin)
        {
            dias.Add(diaActual);

            diaActual = diaActual.AddDays(1);
        }

        return dias;
    }

    public static String ObtenerDiaSemanaCRCulture(DateOnly fecha) => new CultureInfo("es-CR").DateTimeFormat.GetDayName(fecha.DayOfWeek).Capitalize().Replace("é","e").Replace("á","a");
   
}
