using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceImpuesto
{
    Task<ICollection<ImpuestoDto>> ListAllAsync();
}