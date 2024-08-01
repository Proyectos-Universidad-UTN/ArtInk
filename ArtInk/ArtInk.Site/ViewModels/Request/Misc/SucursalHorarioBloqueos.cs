using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request.Misc;

public class SucursalHorarioBloqueos
{
    public short IdSucursalHorario { get; set; }
    
    public char Accion { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public SucursalHorarioResponseDto SucursalHorario { get; set; } = new SucursalHorarioResponseDto();

    public List<SucursalHorarioBloqueoRequestDto> Bloqueos { get; set; } = new List<SucursalHorarioBloqueoRequestDto>();

    public void PrecargarBloqueos()
    {
        if (SucursalHorario.SucursalHorarioBloqueos == null) return;

        foreach (var bloqueo in SucursalHorario.SucursalHorarioBloqueos)
        {
            var sucursalHorarioBloqueoRequest = new SucursalHorarioBloqueoRequestDto()
            {
                IdSucursalHorario = SucursalHorario.Id,
                HoraInicio = bloqueo.HoraInicio,
                HoraFin = bloqueo.HoraFin,
            };

            Bloqueos.Add(sucursalHorarioBloqueoRequest);
        }
    }
}