namespace ArtInk.Application.DTOs;

public record ReservaServicioDto 
{
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public byte IdServicio { get; set; }

    public virtual ReservaDto Reserva { get; set; } = null!;

    public virtual ServicioDto Servicio { get; set; } = null!;
}