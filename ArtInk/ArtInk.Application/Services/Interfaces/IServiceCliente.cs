using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceCliente
{
    Task<ICollection<ClienteDto>> ListAllAsync();
}