﻿using ArtInk.Site.ViewModels.Common;
using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record HorarioResponseDto
{
    public short Id { get; set; }

    [DisplayName("Día")]
    public DiaSemana Dia { get; set; }

    [DisplayName("Hora Inicio")]
    public TimeOnly HoraInicio { get; set; }

    [DisplayName("Hora Final")]
    public TimeOnly HoraFin { get; set; }

    public virtual ICollection<SucursalHorarioResponseDto> SucursalHorarios { get; set; } = new List<SucursalHorarioResponseDto>();

    public string HorarioFormateado
    {
        get
        {
            return $"{HoraInicio.ToString("HH:mm")} - {HoraFin.ToString("HH:mm")}";
        }
    }
    private string? NombreSelectFormateado;

    public string NombreSelect
    {
        get
        {
            return NombreSelectFormateado ?? $"{Dia}-{HorarioFormateado}";
        }

        set
        {
            NombreSelectFormateado = value;
        }
    }
}