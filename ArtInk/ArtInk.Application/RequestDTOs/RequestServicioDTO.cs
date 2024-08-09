namespace ArtInk.Application.RequestDTOs;

public record RequestServicioDto: RequestBaseDTO
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public byte IdTipoServicio { get; set; }

    public decimal Tarifa { get; set; }

    public string? Observacion { get; set; }

    public bool Activo { get; set; }
}