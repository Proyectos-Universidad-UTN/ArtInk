using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class Factura
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

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Impuesto IdImpuestoNavigation { get; set; } = null!;

    public virtual TipoPago IdTipoPagoNavigation { get; set; } = null!;

    public virtual UsuarioSucursal IdUsuarioSucursalNavigation { get; set; } = null!;
}
