using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record HorarioDTO : BaseEntity
{
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public DateOnly Dia { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public virtual SucursalDTO Sucursal { get; set; } = null!;

    public virtual ICollection<SucursalHorarioDTO> SucursalHorarios { get; set; } = new List<SucursalHorarioDTO>();
}