﻿using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceFactura(IRepositoryFactura repository, IMapper mapper) : IServiceFactura
{
    public async Task<FacturaDto> FindByIdAsync(long id)
    {
        var factura = await repository.FindByIdAsync(id);
        if (factura == null) throw new NotFoundException("Factura no encontrada.");

        return mapper.Map<FacturaDto>(factura);
    }

    public async Task<ICollection<FacturaDto>> ListAsync()
    {
        var list = await repository.ListAsync();
        list = list.OrderByDescending(x => x.Fecha).ToList();
        var collection = mapper.Map<ICollection<FacturaDto>>(list);

        return collection;
    }
}