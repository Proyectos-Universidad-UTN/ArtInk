using ArtInk.Site.ViewModels.Common;
using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record HorarioResponseDTO
    {
        public short Id { get; set; }

        [DisplayName("Día")]
        public DiaSemana Dia { get; set; }

        [DisplayName("Hora Inicio")]
        public TimeOnly HoraInicio { get; set; }

        [DisplayName("Hora Final")]
        public TimeOnly HoraFin { get; set; }

        public virtual ICollection<SucursalHorarioResponseDTO> SucursalHorarios { get; set; } = new List<SucursalHorarioResponseDTO>();

        public string HorarioFormateado
        {
            get
            {
                return $"{HoraInicio}-{HoraFin}";
            }
        }
        private string? NombreSelectFormateado;

        public string NombreSelect
        {
            get
            {
                return NombreSelectFormateado ?? $"{Dia}-{HorarioFormateado}";
            }

            set 
            {
                NombreSelectFormateado = value; 
            }
        }
    }
}