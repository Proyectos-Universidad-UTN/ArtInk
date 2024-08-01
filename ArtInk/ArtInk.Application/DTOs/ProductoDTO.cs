using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record ProductoDto : BaseEntity
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public byte IdCategoria { get; set; }

    public decimal Costo { get; set; }

    public string Sku { get; set; } = null!;

    public byte IdUnidadMedida { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<DetalleFacturaProductoDto> DetalleFacturaProductos { get; set; } = new List<DetalleFacturaProductoDto>();

    public virtual CategoriaDto Categoria { get; set; } = null!;

    public virtual UnidadMedidaDto UnidadMedida { get; set; } = null!;

    public virtual ICollection<InventarioDto> Inventarios { get; set; } = new List<InventarioDto>();

    public virtual ICollection<InventarioProductoDto> InventarioProductos { get; set; } = new List<InventarioProductoDto>();
}