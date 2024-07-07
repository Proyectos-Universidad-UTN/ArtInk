using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request.Misc;

public record SucursalSucursalFeriado
{
    public SucursalResponseDTO Sucursal { get; set; } = null!;

    public char Accion { get; set; }

    public byte IdFeriado { get; set; }

    public short Anno { get; set; }

    public IEnumerable<FeriadoResponseDTO> Feriados { get; set; } = null!;

    public List<SucursalFeriadoRequestDTO> FeriadosSucursal { get; set; } = null!;

    public void CargarFeriados(IEnumerable<SucursalFeriadoRequestDTO> feriadosExistentes, IEnumerable<FeriadoResponseDTO> feriados, short anno)
    {
        if (feriadosExistentes != null)
        {
            FeriadosSucursal = feriadosExistentes.ToList();
            return;
        }

        FeriadosSucursal = new List<SucursalFeriadoRequestDTO>();
        foreach (var item in feriados)
        {
            FeriadosSucursal.Add(new SucursalFeriadoRequestDTO()
            {
                IdFeriado = item.Id,
                IdSucursal = Sucursal.Id,
                Fecha = new DateOnly(anno, (int)item.Mes, item.Dia),
                Feriado = item,
                Anno = anno
            });
        }
    }
}