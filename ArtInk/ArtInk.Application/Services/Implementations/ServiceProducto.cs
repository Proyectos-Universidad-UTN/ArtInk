using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Implementations;
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
        public async Task<ProductoDTO> CreateProductoAsync(RequestProductoDTO producto)
        {
            var result = await repository.CreateProductoAsync(mapper.Map<Producto>(producto));
            if (result == null) throw new Exception("Producto no creado.");
            return mapper.Map<ProductoDTO>(result);
        }

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
