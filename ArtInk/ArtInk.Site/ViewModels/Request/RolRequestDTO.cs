﻿using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record RolRequestDto
{
    public byte Id { get; set; }

    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public bool Activo { get; set; }
}