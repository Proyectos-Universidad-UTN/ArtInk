using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Common
{
    public enum DiaSemana
    {
        Lunes = 1,
        Martes = 2,
        [Description("Miércoles")]
        Miercoles = 3,
        Jueves = 4,
        Viernes = 5,
        [Description("Sábado")]
        Sabado = 6,
        Domingo = 7,
    }
}
