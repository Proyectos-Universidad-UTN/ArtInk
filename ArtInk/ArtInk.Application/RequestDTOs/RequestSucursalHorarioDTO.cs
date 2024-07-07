namespace ArtInk.Application.RequestDTOs;

public record RequestSucursalHorarioDTO
{
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public short IdHorario { get; set; }
}