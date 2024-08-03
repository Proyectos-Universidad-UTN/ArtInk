using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;

namespace ArtInk.Site.ViewModels.Request.Misc;

public class SucursalHorarioBloqueos
{
    public short IdSucursalHorario { get; set; }

    public char Accion { get; set; }

    public long IdBloqueo { get; set; }

    [DisplayName("Hora inicio")]
    public TimeOnly HoraInicio { get; set; }

    [DisplayName("Hora fin")]
    public TimeOnly HoraFin { get; set; }

    public SucursalHorarioResponseDto SucursalHorario { get; set; } = new SucursalHorarioResponseDto();

    public List<SucursalHorarioBloqueoRequestDto> Bloqueos { get; set; } = new List<SucursalHorarioBloqueoRequestDto>();

    public List<ReservaHorario> Horas = new List<ReservaHorario>();

    public void PrecargarBloqueos()
    {
        if (SucursalHorario.SucursalHorarioBloqueos == null) return;

        SetearHoras();

        foreach (var bloqueo in SucursalHorario.SucursalHorarioBloqueos.Select((x, i) => new { Value = x, Index = i }))
        {
            var sucursalHorarioBloqueoRequest = new SucursalHorarioBloqueoRequestDto()
            {
                Id = bloqueo.Index,
                IdSucursalHorario = SucursalHorario.Id,
                HoraInicio = bloqueo.Value.HoraInicio,
                HoraFin = bloqueo.Value.HoraFin,
            };

            Bloqueos.Add(sucursalHorarioBloqueoRequest);
        }
    }

    public void SetearHoras()
    {
        var horas = ManejoFechaHora.ObtenerHoras(SucursalHorario.Horario.HoraInicio, SucursalHorario.Horario.HoraFin);
        Horas = (from a in horas select new ReservaHorario() { Horario = a }).ToList();
    }

    public bool HorariosIguales() => HoraFin == HoraInicio;

    public bool HorarioInicioMayorHorarioFin() => HoraFin < HoraInicio;

    public bool HorarioTraslapados()
    {
        var horarioInicioTraslapado = from a in Bloqueos
                                      where (HoraInicio >= a.HoraInicio && HoraInicio < a.HoraFin)
                                      || (HoraFin > a.HoraInicio && HoraFin <= a.HoraFin)
                                      || (HoraInicio <= a.HoraInicio && HoraFin >= a.HoraFin)
                                      select a;
        return horarioInicioTraslapado.ToList().Count > 0;
    }

    public void AgregarBloqueo()
    {
        var bloqueo = new SucursalHorarioBloqueoRequestDto()
        {
            Id = ObtenerSiguienteIdDisponibleBloqueo(),
            HoraInicio = HoraInicio,
            HoraFin = HoraFin,
        };
        Bloqueos.Add(bloqueo);
    }

    public void EliminarBloqueo(long Id)
    {
        var bloqueoExistente = Bloqueos.Single(m => m.Id == Id);
        Bloqueos.Remove(bloqueoExistente);
        OrdenarNumeroLineasDetalle();
    }

    private void OrdenarNumeroLineasDetalle()
    {
        var conteoTotal = Bloqueos.Count;
        Bloqueos.ForEach(m => { conteoTotal--; m.Id = (long)(Bloqueos.Count - conteoTotal); });
    }

    public long ObtenerSiguienteIdDisponibleBloqueo() => Bloqueos.Count == 0 ? (long)1 : (long)(Bloqueos.Max(m => m.Id) + 1);
}