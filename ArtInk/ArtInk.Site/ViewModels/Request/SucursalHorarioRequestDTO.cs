using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record SucursalHorarioRequestDTO
    {
        public short Id { get; set; }

        [DisplayName("Sucursal")]
        public byte IdSucursal { get; set; }

        [DisplayName("Horario")]
        public short IdHorario { get; set; }
    }
}
