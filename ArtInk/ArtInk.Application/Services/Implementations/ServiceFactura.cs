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
    public class ServiceFactura(IRepositoryFactura repository, IMapper mapper) : IServiceFactura
    {
        public async Task<FacturaDTO> FindByIdAsync(long id)
        {
            var factura = await repository.FindByIdAsync(id);
            if (factura == null) throw new Exception("Factura no encontrada.");

            return mapper.Map<FacturaDTO>(factura);
        }

        public async Task<ICollection<FacturaDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            list = list.OrderByDescending(x => x.Fecha).ToList();    
            var collection = mapper.Map<ICollection<FacturaDTO>>(list);

            return collection;
        }

    }
}
