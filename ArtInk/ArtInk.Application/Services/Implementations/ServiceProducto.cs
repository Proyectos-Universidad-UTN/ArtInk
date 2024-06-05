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
    public class ServiceProducto (IRepositoryProducto repository, IMapper mapper) : IServiceProducto
    {
        public async Task<ProductoDTO> FindByIdAsync(int id)
        {
            var producto = await repository.FindByIdAsync(id);
            return mapper.Map<ProductoDTO>(producto);
        }
        public async Task<ICollection<ProductoDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await repository.ListAsync();
            // Map List<Autor> a ICollection<BodegaDTO>
            var collection = mapper.Map<ICollection<ProductoDTO>>(list);
            // Return lista
            return collection;
        }

    }
}
