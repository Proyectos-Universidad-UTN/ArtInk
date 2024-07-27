using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceCliente(IRepositoryCliente repository, IMapper mapper) : IServiceCliente
{
    public async Task<ICollection<ClienteDto>> ListAllAsync()
    {
        var clientes = await repository.ListAllAsync();
        return mapper.Map<ICollection<ClienteDto>>(clientes);
    }
}