namespace ArtInk.Application.DTOs;

public record ReservaServicioDTO 
{
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public byte IdServicio { get; set; }

    public virtual ReservaDTO Reserva { get; set; } = null!;

    public virtual ServicioDTO Servicio { get; set; } = null!;
}