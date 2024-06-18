using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs;

public record DetalleFacturaDTO
{
    public long Id { get; set; }

    public long IdFactura { get; set; }

    public byte IdServicio { get; set; }

    public byte NumeroLinea { get; set; }

    public short Cantidad { get; set; }

    public decimal TarifaServicio { get; set; }

    public decimal MontoSubtotal { get; set; }

    public decimal MontoImpuesto { get; set; }

    public decimal MontoTotal { get; set; }

    public virtual ICollection<DetalleFacturaProductoDTO> DetalleFacturaProductos { get; set; } = new List<DetalleFacturaProductoDTO>();

    public virtual FacturaDTO Factura { get; set; } = null!;

    public virtual ServicioDTO Servicio { get; set; } = null!;
}