using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

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

        public decimal Costo 
        {
            get => !string.IsNullOrEmpty(CostoFormateado) ? Decimal.Parse(CostoFormateado.Replace(",", ""), CultureInfo.InvariantCulture) : 0;
            set
            {
                CostoFormateado = value.ToString("#,##0.00");
            } 
        }

        [NotMapped]
        [DisplayName("Costo ¢")]
        [Required(ErrorMessage = "El costo es obligatorio")]
        [RegularExpression(@"^(?!0+\.00)(?=.{1,9}(\.|$))\d{1,3}(,\d{3})*(\.\d+)?$", ErrorMessage = "Ingrese un valor válido y mayor a 0")]
        public string CostoFormateado { get; set; } = null!;

        [Required(ErrorMessage = "El SKU es obligatorio")]
        public string Sku { get; set; } = null!;

        public decimal Cantidad 
        {
            get => !string.IsNullOrEmpty(CantidadFormateada) ? Decimal.Parse(CantidadFormateada.Replace(",", ""), CultureInfo.InvariantCulture) : 0;
            set
            {
                CantidadFormateada = value.ToString("#,##0.00");
            } 
        }

        [NotMapped]
        [DisplayName("Cantidad")]
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [RegularExpression(@"^(?!0+\.00)(?=.{1,9}(\.|$))\d{1,3}(,\d{3})*(\.\d+)?$", ErrorMessage = "Ingrese un valor válido y mayor a 0")]
        public string CantidadFormateada { get; set; } = null!;

        [DisplayName("Unidad de Medida")]
        [Required(ErrorMessage = "La unidad de medida es obligatoria")]
        public byte IdUnidadMedida { get; set; }

        public bool Activo { get; set; }

        [NotMapped]
        public IEnumerable<CategoriaResponseDTO>? Categorias { get; set; } = null!;

        [NotMapped]
        public IEnumerable<UnidadMedidaResponseDTO>? UnidadMedidas { get; set; } = null!;
    }
}
