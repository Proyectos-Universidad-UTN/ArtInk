using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceServicio
{
    Task<ICollection<ServicioDTO>> ListAsync();

    Task<ServicioDTO> FindByIdAsync(byte id);

    Task<ServicioDTO> CreateServicioAsync(RequestServicioDTO servicio);
}