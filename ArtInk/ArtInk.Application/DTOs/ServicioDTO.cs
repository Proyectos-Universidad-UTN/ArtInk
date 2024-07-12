using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record ServicioDto: BaseEntity
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public byte IdTipoServicio { get; set; }

    public decimal Tarifa { get; set; }

    public string? Observacion { get; set; }

    public bool Activo { get; set; }

     public virtual ICollection<DetalleFacturaDto> DetalleFacturas { get; set; } = new List<DetalleFacturaDto>();

    public virtual TipoServicioDto TipoServicio { get; set; } = null!;

    public virtual ICollection<ReservaServicioDto> ReservaServicios { get; set; } = new List<ReservaServicioDto>();
}