﻿using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record UsuarioSucursalRequestDto
{
    public short Id { get; set; }

    [DisplayName("Usuario")]
    public short IdUsuario { get; set; }

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }
}