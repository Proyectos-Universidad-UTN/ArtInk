using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs;

public record SucursalHorarioDTO
{
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public short IdHorario { get; set; }

    public virtual HorarioDTO Horario { get; set; } = null!;

    public virtual SucursalDTO Sucursal { get; set; } = null!;

    public virtual ICollection<ReservaDTO> Reservas { get; set; } = new List<ReservaDTO>();

    public virtual ICollection<SucursalHorarioBloqueoDTO> SucursalHorarioBloqueos { get; set; } = new List<SucursalHorarioBloqueoDTO>();

}