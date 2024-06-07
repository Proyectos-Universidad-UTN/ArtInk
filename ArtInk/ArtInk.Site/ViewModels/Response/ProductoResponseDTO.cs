namespace ArtInk.Site.ViewModels.Response
{
    public record ProductoResponseDTO
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

        public virtual CategoriaResponseDTO Categoria { get; set; } = null!;

        public virtual UnidadMedidaResponseDTO UnidadMedida { get; set; } = null!;

        //public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
    }
}
