using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositorySucursalHorarioBloqueo
{
    Task<SucursalHorarioBloqueo> CreateSucursalHorarioBloqueolAsync(SucursalHorarioBloqueo bloqueo);

    Task<SucursalHorarioBloqueo> UpdateSucursalHorarioBloqueolAsync(SucursalHorarioBloqueo bloqueo);

    Task<ICollection<SucursalHorarioBloqueo>> GetSucursalHorarioBloqueosBySucursalHorarioAsync(short idSucursalHorario);

    Task<SucursalHorarioBloqueo?> FindByIdAsync(long id);

    Task<bool> ExisteHorarioBloqueo(long id);
}
