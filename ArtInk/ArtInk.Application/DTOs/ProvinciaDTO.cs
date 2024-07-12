namespace ArtInk.Application.DTOs;

public record ProvinciaDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<CantonDto> Cantons { get; set; } = new List<CantonDto>();
}