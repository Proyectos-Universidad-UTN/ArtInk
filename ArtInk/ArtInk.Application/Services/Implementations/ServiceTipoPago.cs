using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceTipoPago(IRepositoryTipoPago repository, IMapper mapper) : IServiceTipoPago
{
    public async Task<ICollection<TipoPagoDto>> ListAllAsync()
    {
        var coleccion = await repository.ListAllAsync();
        return mapper.Map<ICollection<TipoPagoDto>>(coleccion);
    }
}