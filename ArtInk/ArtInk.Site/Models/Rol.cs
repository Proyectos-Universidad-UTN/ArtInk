using System.ComponentModel;

namespace ArtInk.Site.Models;

public enum Rol
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