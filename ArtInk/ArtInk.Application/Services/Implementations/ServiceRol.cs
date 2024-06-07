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
    public class ServiceRol(IRepositoryRol repository, IMapper mapper) : IServiceRol
    {
        public async Task<RolDTO> FindByIdAsync(byte id)
        {
            var rol = await repository.FindByIdAsync(id);
            if (rol == null) throw new Exception("Rol no encontrado.");

            return mapper.Map<RolDTO>(rol);
        }
        public async Task<ICollection<RolDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await repository.ListAsync();
            // Map List<Autor> a ICollection<BodegaDTO>
            var collection = mapper.Map<ICollection<RolDTO>>(list);
            // Return lista
            return collection;
        }
    }
}
