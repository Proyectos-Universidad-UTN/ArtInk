namespace ArtInk.Application.RequestDTOs;

public record RequestReservaPreguntaDto
{
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public string Pregunta { get; set; } = null!;

    public bool Activo { get; set; }

    public string? Respuesta { get; set; }
}