using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceUnidadMedida
{
    Task<ICollection<UnidadMedidaDto>> ListAsync();

    Task<UnidadMedidaDto> FindByIdAsync(byte id);
}