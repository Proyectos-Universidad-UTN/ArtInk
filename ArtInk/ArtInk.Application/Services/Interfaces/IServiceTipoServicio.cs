using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceTipoServicio
{
    Task<ICollection<TipoServicioDTO>> ListAsync();

    Task<TipoServicioDTO> FindByIdAsync(byte id);
}