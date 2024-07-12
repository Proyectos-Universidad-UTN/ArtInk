using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceDetalleFactura(IRepositoryDetalleFactura repository, IMapper mapper) : IServiceDetalleFactura
{
    public async Task<DetalleFacturaDto> FindByIdAsync(long idFactura, long id)
    {
        var detalleFactura = await repository.FindByIdAsync(idFactura, id);
        if (detalleFactura == null) throw new NotFoundException("Detalle Factura no encontrada.");

        return mapper.Map<DetalleFacturaDto>(detalleFactura);
    }

    public async Task<ICollection<DetalleFacturaDto>> ListAsync(long idFactura)
    {
        var list = await repository.ListAsync(idFactura);
        var collection = mapper.Map<ICollection<DetalleFacturaDto>>(list);

        return collection;
    }
}