using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs.Enums
{
    public enum RolEnum
    {
        [Description("Administrador")]
        ADMINISTRADOR = 1,

        [Description("Usuario")]
        USUARIO = 2,

        [Description("Moderador")]
        MODERADOR = 3,

        [Description("Invitado")]
        INVITADO = 4
    }
}
