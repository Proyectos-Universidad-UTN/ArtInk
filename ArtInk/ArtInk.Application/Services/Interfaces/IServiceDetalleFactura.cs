using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceDetalleFactura
{
    Task<DetalleFacturaDTO> FindByIdAsync(long idFactura, long id);

    Task<ICollection<DetalleFacturaDTO>> ListAsync(long idFactura);
}