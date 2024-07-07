using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceFactura
{
    Task<ICollection<FacturaDTO>> ListAsync();

    Task<FacturaDTO> FindByIdAsync(long id);
}