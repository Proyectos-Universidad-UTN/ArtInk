namespace ArtInk.Site.ViewModels.Response
{
    public record ReservaResponseDTO
    {
        public int Id { get; set; }

        public DateOnly Fecha { get; set; }

        public TimeOnly Hora { get; set; }

        public short IdSucursalHorario { get; set; }

        public string Estado { get; set; } = null!;

        public bool Activo { get; set; }

        public virtual SucursalHorarioResponseDTO SucursalHorario { get; set; } = null!;

        public virtual ICollection<ReservaPreguntaResponseDTO> ReservaPregunta { get; set; } = new List<ReservaPreguntaResponseDTO>();

        public virtual ICollection<ReservaServicioResponseDTO> ReservaServicios { get; set; } = new List<ReservaServicioResponseDTO>();
    }
}