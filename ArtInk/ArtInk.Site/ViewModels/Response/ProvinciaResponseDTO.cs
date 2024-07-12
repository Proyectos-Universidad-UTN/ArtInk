namespace ArtInk.Site.ViewModels.Response;

public record ProvinciaResponseDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<CantonResponseDto> Cantons { get; set; } = new List<CantonResponseDto>();
}