using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceUnidadMedida
{
    Task<ICollection<UnidadMedidaDTO>> ListAsync();

    Task<UnidadMedidaDTO> FindByIdAsync(byte id);
}
