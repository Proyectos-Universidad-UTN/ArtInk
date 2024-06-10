namespace ArtInk.Site.ViewModels.Response
{
    public record HorarioResponseDTO
    {
        public short Id { get; set; }

        public byte IdSucursal { get; set; }

        public DateOnly Dia { get; set; }

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFin { get; set; }

        public virtual SucursalResponseDTO Sucursal { get; set; } = null!;

        //public virtual ICollection<SucursalHorarioDTO> SucursalHorarios { get; set; } = new List<SucursalHorarioDTO>();
    }
}
