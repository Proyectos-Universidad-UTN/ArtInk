using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations
{
    public class ServiceUsuario(IRepositoryUsuario repository, IMapper mapper) : IServiceUsuario
    {
        public async Task<UsuarioDTO> FindByIdAsync(int id)
        {
            var usuario = await repository.FindByIdAsync(id);
            return mapper.Map<UsuarioDTO>(usuario);
        }
        public async Task<ICollection<UsuarioDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await repository.ListAsync();
            // Map List<Autor> a ICollection<BodegaDTO>
            var collection = mapper.Map<ICollection<UsuarioDTO>>(list);
            // Return lista
            return collection;
        }
    }
}
