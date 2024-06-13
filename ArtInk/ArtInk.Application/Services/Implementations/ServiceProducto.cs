using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
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
       
        public async Task<ProductoDTO> FindByIdAsync(short id)
        {
            var producto = await repository.FindByIdAsync(id);
            if (producto == null) throw new Exception("Producto no encontrado.");

            return mapper.Map<ProductoDTO>(producto);
        }
        public async Task<ICollection<ProductoDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<ProductoDTO>>(list);

            return collection;
        }

    }
}
