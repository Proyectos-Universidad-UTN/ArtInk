namespace ArtInk.Application.RequestDTOs;

public record RequestReservaServicioDTO
{
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public byte IdServicio { get; set; }
}