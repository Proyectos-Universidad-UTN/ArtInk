namespace ArtInk.Application.DTOs;

public record TipoServicioDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public TimeOnly Duracion { get; set; }

    public virtual ICollection<ServicioDto> Servicios { get; set; } = new List<ServicioDto>();
}