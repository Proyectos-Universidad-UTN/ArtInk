﻿using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record RolResponseDto
{
    public byte Id { get; set; }

    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public bool Activo { get; set; }
}