using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record ReservaDTO: BaseEntity
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public short IdSucursalHorario { get; set; }

    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }

    public short IdUsuarioSucursal { get; set; }

    public virtual SucursalHorarioDTO SucursalHorario { get; set; } = null!;

    public virtual UsuarioSucursalDTO UsuarioSucursal { get; set; } = null!;

    public virtual ICollection<ReservaPreguntaDTO> ReservaPregunta { get; set; } = new List<ReservaPreguntaDTO>();

    public virtual ICollection<ReservaServicioDTO> ReservaServicios { get; set; } = new List<ReservaServicioDTO>();

}