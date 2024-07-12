﻿using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record ClienteRequestDto
{
    public short Id { get; set; }

    [DisplayName("Nombre")]
    public string Nombre { get; set; } = null!;

    [DisplayName("Apellidos")]
    public string Apellidos { get; set; } = null!;

    [DisplayName("Correo Electrónico")]
    public string CorreoElectronico { get; set; } = null!;

    [DisplayName("Teléfono")]
    public int Telefono { get; set; }

    [DisplayName("Distrito")]
    public short IdDistrito { get; set; }

    [DisplayName("Dirección Exacta")]
    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }
}