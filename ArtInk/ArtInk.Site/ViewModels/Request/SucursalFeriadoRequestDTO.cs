using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request
{
    public record SucursalFeriadoRequestDTO
    {
        public short Id { get; set; }

        [DisplayName("Feriado")]
        public byte IdFeriado { get; set; }

        [DisplayName("Sucursal")]
        public byte IdSucursal { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una fecha")]
        public DateOnly Fecha { get; set; }

        public short Anno { get; set; }

        [NotMapped]
        public FeriadoResponseDTO Feriado { get; set; } = null!;
    }
}
