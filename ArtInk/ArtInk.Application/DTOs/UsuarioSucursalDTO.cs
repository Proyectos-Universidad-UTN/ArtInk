using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs;

public record UsuarioSucursalDTO
{
    public short Id { get; set; }

    public short IdUsuario { get; set; }

    public byte IdSucursal { get; set; }

    public virtual ICollection<FacturaDTO> Facturas { get; set; } = new List<FacturaDTO>();

    public virtual ICollection<ReservaDTO> Reservas { get; set; } = new List<ReservaDTO>();

    public virtual SucursalDTO Sucursal { get; set; } = null!;

    public virtual UsuarioDTO Usuario { get; set; } = null!;
}