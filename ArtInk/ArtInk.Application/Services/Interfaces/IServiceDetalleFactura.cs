using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceDetalleFactura
{
    Task<DetalleFacturaDto> FindByIdAsync(long idFactura, long id);

    Task<ICollection<DetalleFacturaDto>> ListAsync(long idFactura);
}