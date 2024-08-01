using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceImpuesto(IRepositoryImpuesto repository, IMapper mapper) : IServiceImpuesto
{
    public async Task<ICollection<ImpuestoDto>> ListAllAsync()
    {
        var coleccion = await repository.ListAllAsync();
        return mapper.Map<ICollection<ImpuestoDto>>(coleccion);
    }
}