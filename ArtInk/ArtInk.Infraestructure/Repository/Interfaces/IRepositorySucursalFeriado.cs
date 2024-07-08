
using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositorySucursalFeriado
{
    Task<ICollection<SucursalFeriado>> GetFeriadosBySucursalAsync(byte idSucursal);

    Task<ICollection<SucursalFeriado>> GetFeriadosBySucursalAsync(byte idSucursal, short anno);

    Task<SucursalFeriado?> GetSucursalFeriadoByIdAsync(short id);

    Task<bool> CreateSucursalFeriadosAsync(byte idSucursal, IEnumerable<SucursalFeriado> sucursalFeriados);
}
