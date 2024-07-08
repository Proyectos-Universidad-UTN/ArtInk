using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryFeriado
{
    Task<ICollection<Feriado>> ListAsync();

    Task<Feriado?> FindByIdAsync(byte id);

    Task<Feriado> CreateFeriadoAsync(Feriado feriado);

    Task<Feriado> UpdateFeriadoAsync(Feriado feriado);

    Task<bool> ExisteFeriadoAsync(byte id);

    Task<bool> DeleteFeriadoAsync(byte id);
}