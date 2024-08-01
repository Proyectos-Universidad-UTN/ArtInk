namespace ArtInk.Site.ViewModels.Response;

public record ImpuestoResponseDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Porcentaje { get; set; }

    private string nombreSelect;

    public string NombreSelect
    {
        get => Id == 0 ? Nombre : $"{Nombre} - %{Porcentaje}";
        set => nombreSelect = value;
    }

    public virtual ICollection<FacturaResponseDto> Facturas { get; set; } = new List<FacturaResponseDto>();
}