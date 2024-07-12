using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceTipoServicio
{
    Task<ICollection<TipoServicioDto>> ListAsync();

    Task<TipoServicioDto> FindByIdAsync(byte id);
}