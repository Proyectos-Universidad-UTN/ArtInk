using ArtInk.Application.Configuration.Pagination;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceProveedor
{
    Task<ICollection<ProveedorDto>> ListAsync();

    Task<PagedList<ProveedorDto>> ListAsync(PaginationParameters paginationParameters);

    Task<ProveedorDto> FindByIdAsync(byte id);

    Task<ProveedorDto> CreateProveedorAsync(RequestProveedorDto proveedorDto);

    Task<ProveedorDto> UpdateProveedorsync(byte id, RequestProveedorDto proveedorDto);

    Task<bool> DeleteProveedorsyncAsync(byte id);
}