using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Services.Implementations
{
    public class ServiceDetalleFactura(IRepositoryDetalleFactura repository, IMapper mapper) : IServiceDetalleFactura
    {
        public async Task<DetalleFacturaDTO> FindByIdAsync(int id)
        {
            var detalleFactura = await repository.FindByIdAsync(id);
            if (detalleFactura == null) throw new Exception("Detalle Factura no encontrada.");

            return mapper.Map<DetalleFacturaDTO>(detalleFactura);
        }

        public async Task<ICollection<DetalleFacturaDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<DetalleFacturaDTO>>(list);

            return collection;
        }

    }
}
