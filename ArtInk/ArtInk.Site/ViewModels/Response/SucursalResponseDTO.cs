using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record SucursalResponseDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        [DisplayName("Descripción")]
        public string Descripcion { get; set; } = null!;

        [DisplayName("Teléfono")]
        public int Telefono { get; set; }

        [DisplayName("Corro Electrónico")]
        public string CorreoElectronico { get; set; } = null!;

        [DisplayName("Distrito")]
        public short IdDistrito { get; set; }

        [DisplayName("Dirección")]
        public string? DireccionExacta { get; set; }

        public bool Activo { get; set; }

        public virtual ICollection<HorarioResponseDTO> Horarios { get; set; } = new List<HorarioResponseDTO>();

        public virtual DistritoResponseDTO? Distrito { get; set; } = null!;

        public virtual ICollection<InventarioResponseDTO> Inventarios { get; set; } = new List<InventarioResponseDTO>();

        public virtual ICollection<SucursalHorarioResponseDTO> SucursalHorarios { get; set; } = new List<SucursalHorarioResponseDTO>();

        public virtual ICollection<UsuarioSucursalResponseDTO> UsuarioSucursals { get; set; } = new List<UsuarioSucursalResponseDTO>();

        public virtual ICollection<SucursalFeriadoResponseDTO> SucursalFeriados { get; set; } = new List<SucursalFeriadoResponseDTO>();
    }
}
