using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Response
{
    public record ReservaResponseDTO 
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{00}")]
        public DateOnly Fecha { get; set; }

        public TimeOnly Hora { get; set; }

        public short IdSucursalHorario { get; set; }

        public string Estado { get; set; } = null!;

        public bool Activo { get; set; }

        public virtual SucursalHorarioResponseDTO SucursalHorario { get; set; } = null!;

        //public virtual ICollection<ReservaPreguntaDTO> ReservaPregunta { get; set; } = new List<ReservaPreguntaDTO>();

        //public virtual ICollection<ReservaServicioDTO> ReservaServicios { get; set; } = new List<ReservaServicioDTO>();

    }
}
