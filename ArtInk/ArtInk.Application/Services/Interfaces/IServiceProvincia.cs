using ArtInk.Application.DTOs;
namespace ArtInk.Application.Services.Interfaces;

public interface IServiceProvincia
{
    Task<ICollection<ProvinciaDTO>> ListAsync();

    Task<ProvinciaDTO> FindByIdAsync(byte id);
}