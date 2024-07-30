using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceFactura
{
    Task<ICollection<FacturaDto>> ListAsync();

    Task<FacturaDto> FindByIdAsync(long id);
    Task<FacturaDto> CreateFacturaAsync(RequestFacturaDto facturaDto);
}