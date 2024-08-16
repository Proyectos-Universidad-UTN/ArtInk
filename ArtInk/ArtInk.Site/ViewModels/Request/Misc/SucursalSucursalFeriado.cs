using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request.Misc;

public record SucursalSucursalFeriado
{
    public SucursalResponseDto Sucursal { get; set; } = null!;

    public char Accion { get; set; }

    public byte IdFeriado { get; set; }

    public short Anno { get; set; }

    public List<FeriadoResponseDto> Feriados { get; set; } = new List<FeriadoResponseDto>();

    public List<SucursalFeriadoRequestDto> FeriadosSucursal { get; set; } = null!;

    public void CargarFeriados(IEnumerable<SucursalFeriadoRequestDto> feriadosExistentes, IEnumerable<FeriadoResponseDto> feriados, short anno)
    {
        if (feriadosExistentes.Any())
        {
            FeriadosSucursal = feriadosExistentes.ToList();
            return;
        }

        FeriadosSucursal = new List<SucursalFeriadoRequestDto>();
        foreach (var item in feriados)
        {
            if (item.Id == 0) continue;
            FeriadosSucursal.Add(new SucursalFeriadoRequestDto()
            {
                IdFeriado = item.Id,
                IdSucursal = Sucursal.Id,
                Fecha = new DateOnly(anno, (int)item.Mes, item.Dia),
                Feriado = item,
                Anno = anno
            });
        }
    }

    public void AgregarFeriado(SucursalFeriadoRequestDto sucursalFeriado)
    {
        FeriadosSucursal.Add(sucursalFeriado);
        FeriadosSucursal = FeriadosSucursal.OrderBy(m => m.Fecha).ToList();
    }

    public void EliminarFeriado() => FeriadosSucursal = FeriadosSucursal.Where(m => m.IdFeriado != IdFeriado).ToList();
}