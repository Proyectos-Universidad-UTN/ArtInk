using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record SucursalDTO: BaseEntity
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Telefono { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public short IdDistrito { get; set; }

    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<FeriadoDTO> Feriados { get; set; } = new List<FeriadoDTO>();

    public virtual ICollection<HorarioDTO> Horarios { get; set; } = new List<HorarioDTO>();

    public virtual DistritoDTO? Distrito { get; set; } = null!;

    public virtual ICollection<InventarioDTO> Inventarios { get; set; } = new List<InventarioDTO>();

    public virtual ICollection<SucursalHorarioDTO> SucursalHorarios { get; set; } = new List<SucursalHorarioDTO>();

    public virtual ICollection<UsuarioSucursalDTO> UsuarioSucursals { get; set; } = new List<UsuarioSucursalDTO>();
}