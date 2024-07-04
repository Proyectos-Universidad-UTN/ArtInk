using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Request
{
    public record ProductoRequestDTO
    {
        public short Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = null!;

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca { get; set; } = null!;

        [DisplayName("Categoría")]
        [Required(ErrorMessage = "La categoría es obligatoria")]
        public byte IdCategoria { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El costo debe ser mayor a 0")]
        [Required(ErrorMessage = "El costo es obligatorio")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "El SKU es obligatorio")]
        public string Sku { get; set; } = null!;

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public decimal Cantidad { get; set; }

        [DisplayName("Unidad de Medida")]
        [Required(ErrorMessage = "La unidad de medida es obligatoria")]
        public byte IdUnidadMedida { get; set; }

        public bool Activo { get; set; }

        public IEnumerable<CategoriaResponseDTO> Categorias { get; set; } = null!;

        public IEnumerable<UnidadMedidaResponseDTO> UnidadMedidas { get; set; } = null!;
    }
}
