using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceTipoPago
{
    Task<ICollection<TipoPagoDto>> ListAllAsync();
}