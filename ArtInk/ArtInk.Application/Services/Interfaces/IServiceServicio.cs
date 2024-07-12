using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceServicio
{
    Task<ICollection<ServicioDto>> ListAsync();

    Task<ServicioDto> FindByIdAsync(byte id);

    Task<ServicioDto> CreateServicioAsync(RequestServicioDto servicio);

    Task<ServicioDto> UpdateServicioAsync(byte id, RequestServicioDto servicioDTO);
}