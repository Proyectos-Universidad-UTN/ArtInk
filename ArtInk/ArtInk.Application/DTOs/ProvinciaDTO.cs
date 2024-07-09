namespace ArtInk.Application.DTOs;

public record ProvinciaDTO
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<CantonDTO> Cantons { get; set; } = new List<CantonDTO>();
}