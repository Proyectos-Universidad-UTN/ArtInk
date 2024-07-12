﻿using ArtInk.Site.ViewModels.Common;
using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record HorarioRequestDto
{
    public short Id { get; set; }

    [DisplayName("Día")]
    public DiaSemana Dia { get; set; }

    [DisplayName("Hora Inicio")]
    public TimeOnly HoraInicio { get; set; }

    [DisplayName("Hora Final")]
    public TimeOnly HoraFin { get; set; }
}