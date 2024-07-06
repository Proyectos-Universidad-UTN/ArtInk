using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs.Enums
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
