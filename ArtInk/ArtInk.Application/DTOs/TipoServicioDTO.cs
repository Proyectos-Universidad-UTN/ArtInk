namespace ArtInk.Application.DTOs;

public record TipoServicioDTO
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public TimeOnly Duracion { get; set; }

    public virtual ICollection<ServicioDTO> Servicios { get; set; } = new List<ServicioDTO>();
}