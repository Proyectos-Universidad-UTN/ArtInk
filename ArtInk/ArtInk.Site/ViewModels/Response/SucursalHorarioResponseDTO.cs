namespace ArtInk.Site.ViewModels.Response
{
    public record SucursalHorarioResponseDTO
    {
        public short Id { get; set; }

        public byte IdSucursal { get; set; }

        public short IdHorario { get; set; }

        public virtual HorarioResponseDTO Horario { get; set; } = null!;

        public virtual SucursalResponseDTO Sucursal { get; set; } = null!;

        //public virtual ICollection<ReservaDTO> Reservas { get; set; } = new List<ReservaDTO>();
    }
}
