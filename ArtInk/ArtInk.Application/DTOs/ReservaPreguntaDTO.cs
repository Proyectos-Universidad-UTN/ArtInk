using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record ReservaPreguntaDto: BaseEntity
{
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public string Pregunta { get; set; } = null!;

    public bool Activo { get; set; }

    public string? Respuesta { get; set; }

    public virtual ReservaDto Reserva { get; set; } = null!;
}