using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServicePedido
{
    Task<PedidoDto> CreatePedidoAsync(RequestPedidoDto pedidoDto);

    Task<ICollection<PedidoDto>> ListAsync();
}