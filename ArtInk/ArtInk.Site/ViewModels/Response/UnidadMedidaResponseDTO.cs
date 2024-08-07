﻿using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record UnidadMedidaResponseDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Símbolo")]
    public string Simbolo { get; set; } = null!;
}