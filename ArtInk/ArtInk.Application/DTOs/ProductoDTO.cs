
using ArtInk.Application.DTOs.Base;
using ArtInk.Infraestructure.Models;

namespace ArtInk.Application.DTOs
{
    public record ProductoDTO : BaseEntity
    {
        public short Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string Marca { get; set; } = null!;

        public byte IdCategoria { get; set; }

        public decimal Costo { get; set; }

        public string Sku { get; set; } = null!;

        public decimal Cantidad { get; set; }

        public byte IdUnidadMedida { get; set; }

        public bool Activo { get; set; }


        //public virtual ICollection<DetalleFacturaProducto> DetalleFacturaProductos { get; set; } = new List<DetalleFacturaProducto>();

        public virtual Categorium IdCategoriaNavigation { get; set; } = null!;

        public virtual UnidadMedidum IdUnidadMedidaNavigation { get; set; } = null!;

        //public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    }
}
