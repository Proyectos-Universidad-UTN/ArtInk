using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record SucursalFeriadoResponseDTO
    {
        public short Id { get; set; }

        [DisplayName("Feriado")]
        public byte IdFeriado { get; set; }

        [DisplayName("Sucursal")]
        public byte IdSucursal { get; set; }

        public virtual FeriadoResponseDTO Feriado { get; set; } = null!;

        public virtual SucursalResponseDTO Sucursal { get; set; } = null!;
    }
}