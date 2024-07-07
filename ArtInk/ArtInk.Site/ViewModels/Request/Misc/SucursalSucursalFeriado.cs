using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request.Misc;

public record SucursalSucursalFeriado
{
    public SucursalResponseDTO Sucursal { get; set; } = null!;

    public List<SucursalFeriadoRequestDTO> FeriadosSucursal { get; set; } = null!;

    public void CargarFeriados(IEnumerable<FeriadoResponseDTO> feriados, short anno)
    {
        FeriadosSucursal = new List<SucursalFeriadoRequestDTO>();
        foreach (var item in feriados)
        {
            FeriadosSucursal.Add(new SucursalFeriadoRequestDTO()
            {
                IdFeriado = item.Id,
                IdSucursal = Sucursal.Id,
                Fecha = new DateOnly(anno, (int)item.Mes, item.Dia),
                Feriado = item,
                Ano = anno
            });
        }
    }
}