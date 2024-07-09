using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceCategoria
{
    Task<ICollection<CategoriaDTO>> ListAsync();
    
    Task<CategoriaDTO> FindByIdAsync(byte id);
}