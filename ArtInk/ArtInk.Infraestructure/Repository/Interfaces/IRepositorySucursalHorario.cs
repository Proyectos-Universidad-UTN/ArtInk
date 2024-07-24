using ArtInk.Infraestructure.Enums;
using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositorySucursalHorario
{
    Task<ICollection<SucursalHorario>> GetHorariosBySucursalAsync(byte idSucursal);

    Task<SucursalHorario?> GetSucursalHorarioByIdAsync(short id);

    Task<SucursalHorario?> GetHorarioBySucursalByDiaAsync(byte idSucursal, DiaSemana dia);

    Task<bool> CreateSucursalHorariosAsync(byte idSucursal, IEnumerable<SucursalHorario> sucursalHorarios);
}