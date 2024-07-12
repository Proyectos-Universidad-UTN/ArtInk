using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request.Misc;

public record SucursalSucursalHorario
{
    public SucursalResponseDto Sucursal { get; set; } = null!;

    public char Accion { get; set; }

    public byte IdHorario { get; set; }

    public List<HorarioResponseDto> Horarios { get; set; } = new List<HorarioResponseDto>();

    public List<SucursalHorarioRequestDto> HorariosSucursal { get; set; } = null!;

    public void CargarHorarios(IEnumerable<SucursalHorarioRequestDto> horariosExistentes, IEnumerable<HorarioResponseDto> horarios)
    {
        if (horariosExistentes.Any())
        {
            HorariosSucursal = horariosExistentes.ToList();
            return;
        }

        HorariosSucursal = new List<SucursalHorarioRequestDto>();
        foreach (var item in horarios)
        {
            HorariosSucursal.Add(new SucursalHorarioRequestDto()
            {
                IdHorario = item.Id,
                IdSucursal = Sucursal.Id,
                Horario = item
            });
        }
    }
}