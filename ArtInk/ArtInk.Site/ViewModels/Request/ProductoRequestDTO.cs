using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record ProductoRequestDTO
    {
        public short Id { get; set; }

        public string Nombre { get; set; } = null!;

        [DisplayName("Descripción")]
        public string Descripcion { get; set; } = null!;

        public string Marca { get; set; } = null!;

        [DisplayName("Categoría")]
        public byte IdCategoria { get; set; }

        public decimal Costo { get; set; }

        public string Sku { get; set; } = null!;

        public decimal Cantidad { get; set; }

        [DisplayName("Unidad de Medida")]
        public byte IdUnidadMedida { get; set; }

        public bool Activo { get; set; }

        public IEnumerable<CategoriaResponseDTO>  Categorias { get; set; } = null!;

        public IEnumerable<UnidadMedidaResponseDTO> UnidadMedidas { get; set; } = null!;
    }
}
