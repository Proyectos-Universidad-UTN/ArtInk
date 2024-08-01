using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Application.Validations;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceFactura(IRepositoryFactura repository, IMapper mapper,
                            IValidator<Factura> facturaValidator) : IServiceFactura
{
    public async Task<FacturaDto> CreateFacturaAsync(RequestFacturaDto facturaDto)
    {
        var factura = await ValidarFactura(facturaDto);
        factura.IdUsuarioSucursal = 1;

        var result = await repository.CreateFacturaAsync(factura);
        if (result == null) throw new NotFoundException("Factura no creada.");
        
        return mapper.Map<FacturaDto>(result);
    }

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

    private async Task<Factura> ValidarFactura(RequestFacturaDto facturaDto)
    {
        var factura = mapper.Map<Factura>(facturaDto);
        await facturaValidator.ValidateAndThrowAsync(factura);
        return factura;
    }
}