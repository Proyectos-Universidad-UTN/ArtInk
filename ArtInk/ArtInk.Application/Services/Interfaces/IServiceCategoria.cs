using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceCategoria
{
    Task<ICollection<CategoriaDto>> ListAsync();
    
    Task<CategoriaDto> FindByIdAsync(byte id);
}