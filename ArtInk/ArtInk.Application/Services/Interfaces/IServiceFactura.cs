using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceFactura
{
    Task<ICollection<FacturaDto>> ListAsync();

    Task<FacturaDto> FindByIdAsync(long id);
}