using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request.Misc
{
    public record SucursalSucursalHorario
    {
        public SucursalResponseDTO Sucursal { get; set; } = null!;

        public char Accion { get; set; }

        public byte IdHorario { get; set; }

        public IEnumerable<HorarioResponseDTO> Horarios { get; set; } = null!;

        public List<SucursalHorarioRequestDTO> HorariosSucursal { get; set; } = null!;

        public void CargarHorarios(IEnumerable<SucursalHorarioRequestDTO> horariosExistentes, IEnumerable<HorarioResponseDTO> horarios)
        {
            if (horariosExistentes.Count() > 0)
            {
                HorariosSucursal = horariosExistentes.ToList();
                return;
            }

            HorariosSucursal = new List<SucursalHorarioRequestDTO>();
            foreach (var item in horarios)
            {
                HorariosSucursal.Add(new SucursalHorarioRequestDTO()
                {
                    IdHorario = item.Id,
                    IdSucursal = Sucursal.Id,
                    Horario =item
                });
            }
        }
    }
}
