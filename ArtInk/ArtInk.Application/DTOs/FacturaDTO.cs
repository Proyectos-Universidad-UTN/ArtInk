using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record FacturaDTO: BaseEntity
{
    public long Id { get; set; }

    public short IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public byte IdTipoPago { get; set; }

    public short Consecutivo { get; set; }

    public short IdUsuarioSucursal { get; set; }

    public byte IdImpuesto { get; set; }

    public decimal PorcentajeImpuesto { get; set; }

    public decimal SubTotal { get; set; }

    public decimal MontoImpuesto { get; set; }

    public decimal MontoTotal { get; set; }

    public virtual ICollection<DetalleFacturaDTO> DetalleFacturas { get; set; } = new List<DetalleFacturaDTO>();

    public virtual ClienteDTO Cliente { get; set; } = null!;

    public virtual ImpuestoDTO Impuesto { get; set; } = null!;

    public virtual TipoPagoDTO TipoPago { get; set; } = null!;

    public virtual UsuarioSucursalDTO UsuarioSucursal { get; set; } = null!;
}