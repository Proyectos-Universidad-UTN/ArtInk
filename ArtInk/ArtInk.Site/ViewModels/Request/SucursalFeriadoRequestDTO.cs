using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record SucursalFeriadoRequestDTO
    {
        public short Id { get; set; }

        [DisplayName("Feriado")]
        public byte IdFeriado { get; set; }

        [DisplayName("Sucursal")]
        public byte IdSucursal { get; set; }
    }
}
