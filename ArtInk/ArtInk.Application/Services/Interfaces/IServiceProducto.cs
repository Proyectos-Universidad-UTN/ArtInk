using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceProducto
    {
        Task<ICollection<ProductoDTO>> ListAsync();
        Task<ProductoDTO> FindByIdAsync(int id);
    }
}
