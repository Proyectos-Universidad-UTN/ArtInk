﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ArtInk.Application.DTOs.Enums;

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
