using ArtInk.Application.DTOs;
namespace ArtInk.Application.Services.Interfaces;

public interface IServiceProvincia
{
    Task<ICollection<ProvinciaDto>> ListAsync();

    Task<ProvinciaDto> FindByIdAsync(byte id);
}